using System.Reflection;
using System.Runtime.Remoting;
using System.Text;


/* 
Дан класс(ниже), создать методы создающий этот класс, вызывая один 
из его конструкторов (по одному конструктору на метод).

Напишите 2 метода использующие рефлексию
1 - сохраняет информацию о классе в строку
2- позволяет восстановить класс из строки с информацией о методе
В качестве примере класса используйте класс TestClass.
Шаблоны методов для реализации:
static object StringToObject(string s) { }
static string ObjectToString(object o) { }
Подсказка:
Строка должна содержать название класса, полей и значений
Ограничьтесь диапазоном значений представленном в классе
Если класс находится в тоже сборке (наш вариант) то можно не указывать имя сборки в паремтрах активатора.
Activator.CreateInstance(null, “TestClass”) - сработает;
Для простоты представьте что есть только свойства. Не анализируйте поля класса.
Пример того как мог быть выглядеть сохраненный в строку объект: “TestClass, test2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:TestClass|I:1|S:STR|D:2.0|”
Ключ-значения разделяются двоеточием а сами пары - вертикальной чертой.
*/


namespace Task7
{
    class TestClass
    {
        [AliasName("my own int alias")]
        public int I { get; set; }
        [AliasName("my own string alias")]
        public string? S { get; set; }
        public decimal D { get; set; }
        public char[]? C { get; set; }

        public TestClass()
        { }
        public TestClass(int i)
        {
            this.I = i;
        }
        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }
        public override string ToString()
        {
            return $"I={I}, S={S}, D={D}, C={C}";
        }
        public static string ObjectToString(object o)
        {
            Type t = o.GetType();
            StringBuilder result = new StringBuilder();
            result.AppendKeyValue(t.AssemblyQualifiedName, t.Name);
            var prop = t.GetProperties();
            foreach (var p in prop)
            {
                var myAttributes = p.CustomAttributes.Where(x => x.AttributeType.Name.Equals(nameof(AliasNameAttribute)));
                string? alias = GetAliasName(p); 
                string name = alias ?? p.Name;
                var value = p.GetValue(o);
                if (p.PropertyType == typeof(char[]))
                    result.AppendKeyValue(name, new string(value as char[]));
                else
                    result.AppendKeyValue(name, value == null? null : value.ToString());
            }
            return result.ToString();
        }

        private static string? GetAliasName(PropertyInfo property)
        {
            var attributes = property.CustomAttributes.Where(x => x.AttributeType.Name == nameof(AliasNameAttribute));
            if (attributes.Count() > 0) return attributes.First().ConstructorArguments[0].ToString();
            else return null;
        }
    
        public static object? StringToObject(string s)
        {
            string[] arr = s.Split('|');
            string[] arr1 = arr[0].Split(':');
            var result = Activator.CreateInstance(null, arr1[0].Split(',')[0]).Unwrap();

            if (arr1.Length > 1 && result != null)
            {
                var t = result.GetType();
                for (int i = 1; i < arr.Length; i++)
                {
                    string[] keyValue = arr[i].Split(':');
                    var p = t.GetProperty(keyValue[0]);
                    if (p == null)
                    {
                        foreach (var item in t.GetProperties())
                        {
                            if (keyValue[0].Equals(GetAliasName(item))) p = item;
                        }
                    }
                    if (p == null) continue;
                    else 
                    {
                        if (p.PropertyType == typeof(int)) p.SetValue(result, int.Parse(keyValue[1]));
                        if (p.PropertyType == typeof(string)) p.SetValue(result, keyValue[1]);
                        if (p.PropertyType == typeof(decimal)) p.SetValue(result, decimal.Parse(keyValue[1]));
                        if (p.PropertyType == typeof(char[])) p.SetValue(result, keyValue[1].ToCharArray());
                    }
                }
            }
            return result;
        }
    }
}