using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    public static class MyExtensions
    {
        public static void AppendKeyValue(this StringBuilder sb, string? key, string? value)
        {
            sb.Append(key);
            sb.Append(':');
            sb.Append(value);
            sb.Append('|');
        }
    }
}