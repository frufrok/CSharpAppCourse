using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task8
{
    public struct FindResult
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Context { get; set; }
        public override string ToString()
        {
            return $"File {FileName} ({Path}):\r\n\t{Context}";
        }
    }
}