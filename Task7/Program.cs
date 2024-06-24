/* 
Дан класс(ниже), создать методы создающий этот класс, вызывая один 
из его конструкторов (по одному конструктору на метод).
Задача не очень сложна и служит больше для разогрева перед следующей задачей.
*/

TestClass? t1 = TestClass.GetUsingReflection();
TestClass? t2 = TestClass.GetUsingReflection(5);
TestClass? t3 = TestClass.GetUsingReflection(5, "a", 10, ['s', 'b']);

Console.WriteLine(t1);
Console.WriteLine(t2);
Console.WriteLine(t3);
