using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Task9
{
    [XmlRoot("TestClass")]
    public class TestClass
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public override string ToString()
        {
            return $"ID = {ID}, Name = {Name}, CreatedAt = {CreatedAt}";
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(new TestClassWrapper() {TestClass = this});
        }
        public static TestClass? FromJson(string json)
        {
            var wrapper = JsonConvert.DeserializeObject<TestClassWrapper>(json);
            return wrapper != null ? wrapper.TestClass : null;
        }
        public static TestClass? FromXml(XmlDocument xml)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(xml.InnerXml)))
            {
                var serializer = new XmlSerializer(typeof(TestClass));
                var result = serializer.Deserialize(reader);
                return result != null ? (TestClass)result : null;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, CreatedAt);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null && this != null || obj != null && this == null)
            {
                return false;
            }
            else if (obj == null) { return true; }
            else
            {
                if (obj.GetType().Equals(this.GetType()))
                {
                    var that = (TestClass)obj;
                    return this.Name.Equals(that.Name)
                        && this.ID.Equals(that.ID)
                        && this.CreatedAt.Equals(that.CreatedAt);
                }
                else return false;
            }
        }
    }
    
    public class TestClassWrapper
    {
        public TestClass? TestClass { get; set; }
    }
}