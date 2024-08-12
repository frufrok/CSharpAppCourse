using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Task9
{
    public class Json2Xml
    {
        public static XmlDocument? Convert(string json)
        {
            return JsonConvert.DeserializeXmlNode(json);
        }
    }
}