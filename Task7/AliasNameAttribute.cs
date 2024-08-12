using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task7
{
    class AliasNameAttribute : Attribute
    {
        public string Alias { get; }
        public AliasNameAttribute(string aliasName) 
        {
            this.Alias = aliasName;
        }
    }
}