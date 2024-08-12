using Task7;
using System.Reflection;
using System.Runtime.Remoting;
// Дан класс(ниже), создать методы создающий этот класс, вызывая один 
// из его конструкторов (по одному конструктору на метод).
public class Program
{
    public static void Main(string[] args)
    {
        TestClass? t1 = CreateByReflection();
        TestClass? t2 = CreateByReflection(5);
        TestClass? t3 = CreateByReflection(5, "a", 10, ['s', 'b']);

        Console.WriteLine(t1);
        Console.WriteLine(t2);
        Console.WriteLine(t3);

        string s1 = TestClass.ObjectToString(t1);
        string s2 = TestClass.ObjectToString(t2);
        string s3 = TestClass.ObjectToString(t3);

        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);

        var o1 = TestClass.StringToObject(s1);
        var o2 = TestClass.StringToObject(s2);
        var o3 = TestClass.StringToObject(s3);

        Console.WriteLine(((TestClass)o1).ToString());
        Console.WriteLine(((TestClass)o2).ToString());
        Console.WriteLine(((TestClass)o3).ToString());
    }
    private static TestClass? CreateByReflection()
    {
        Type t = typeof(TestClass);
        return Activator.CreateInstance(t) as TestClass;
    }
    private static TestClass? CreateByReflection(int i)
    {
        Type t = typeof(TestClass);
        return Activator.CreateInstance(t, (object[])[i]) as TestClass;
    }
    private static TestClass? CreateByReflection(int i, string s, decimal d, char[] c)
    {
        Type t = typeof(TestClass);
        return Activator.CreateInstance(t, [i, s, d, c]) as TestClass;
    }
}


