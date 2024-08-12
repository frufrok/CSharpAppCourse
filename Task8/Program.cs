using Task8;

public class Program
{
    public static void Main (string[] args)
    {
        if (args.Length == 0)
        {
            string path = "..\\..\\..\\";
            string extension = "txt";
            string text = "окно";
            TextFinder tf = new TextFinder(path, extension, text);
            foreach (var result in tf.FindResults)
            {
                Console.WriteLine(result);
            }
        }
        else if (args.Length == 3)
        {
            string path = args[0];
            string extension = args[1];
            string text = args[2];
            TextFinder tf = new TextFinder(path, extension, text);
            foreach(var result in tf.FindResults)
            {
                Console.WriteLine(result);
            }
        }
        else
        {
            Console.WriteLine("Запустите программу с тремя аргументами:\r\n" +
            "\t <workdir>/Program.exe \"<path>\" \"<extension>\" \"<text>\"");
        }
    }
}