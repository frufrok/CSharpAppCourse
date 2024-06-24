using System.Reflection;
using System.Runtime.Remoting;


/* 
Дан класс(ниже), создать методы создающий этот класс, вызывая один 
из его конструкторов (по одному конструктору на метод).
Задача не очень сложна и служит больше для разогрева перед следующей задачей.
*/
class TestClass
{
    public int I { get; set; }
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
    private static TestClass? GetUnwrapped(ObjectHandle? wrapped)
    {
        if (wrapped != null)
        {
            object? result = wrapped.Unwrap();
            return result == null ? null : (TestClass)result;
        }
        else return null;
    }
    public static TestClass? GetUsingReflection()
    {
        string assemblyName = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name ?? "";
        return GetUnwrapped(Activator.CreateInstance(assemblyName, nameof(TestClass)));
    }
    private static TestClass? GetUnboxed(object? boxed) 
    {
        if (boxed != null) return (TestClass)boxed;
        else return null;
    }
    public static TestClass? GetUsingReflection(int i)
    {
        return GetUnboxed(Activator.CreateInstance(typeof(TestClass), [i]));
    }
    public static TestClass? GetUsingReflection(int i, string s, decimal d, char[] c)
    {
        return GetUnboxed(Activator.CreateInstance(typeof(TestClass), [i, s, d, c]));
    }
}
