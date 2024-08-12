using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    public class TextFinder
    {
        BlockingCollection<FindResult> _results = [];
        public TextFinder(string path, string extension, string text)
        {
            FindRecursive(path, extension, text);
            var list = _results.ToList();
            list.Sort(new Comparison<FindResult>((x, y) => x.Path.CompareTo(y.Path)));
            FindResults = list.ToImmutableList();
        }
        public ImmutableList<FindResult> FindResults { get; init; }

        private void FindRecursive(string path, string extension, string text)
        {
            List<Task> tasks = new List<Task>();
            foreach (var dir in Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly))
            {
                tasks.Add(Task.Run(() => FindRecursive(dir, extension, text)));
            }
            foreach(var file in Directory.GetFiles(path, $"*.{extension}", SearchOption.TopDirectoryOnly))
            {
                tasks.Add(Task.Run(() => FindInText(file, text)));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private void FindInText(string path, string text)
        {
            using (var file = new StreamReader(path, Encoding.UTF8, true, new FileStreamOptions() { Mode = FileMode.Open }))
            {
                while (!file.EndOfStream)
                {
                    var task = file.ReadToEndAsync();
                    task.Wait();
                    var context = task.Result.Split(text, StringSplitOptions.RemoveEmptyEntries);
                    var space = new char[] { ' ' };
                    if (context.Length > 0)
                    {
                        List<List<String>> separated = context.Select(x => x.Split(space).ToList()).ToList();
                        List<int> counts = separated.Select(x => Math.Min(5, x.Count)).ToList();
                        List<int> starts = separated.Select(x => Math.Max(0, x.Count - 5 - 1)).ToList();
                        for (int i = 0; i < context.Length - 1; i++)
                        {
                            string before = string.Join(" ", separated[i].GetRange(starts[i], counts[i])).Replace("\r\n", " ");
                            string after = string.Join(" ", separated[i + 1].GetRange(0, counts[i + 1])).Replace("\r\n", " ");

                            context[i + 1].Split(space).First();
                            var result = new FindResult()
                            {
                                Path = path,
                                FileName = Path.GetFileName(path),
                                Context = $"{before} {text} {after}"
                            };
                            _results.Add(result);
                        }
                    }
                }
            }
        }
    }
}