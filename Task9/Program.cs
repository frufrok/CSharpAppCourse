using Task9;

var original = new TestClass()
{
    ID = 1,
    Name = "User",
    CreatedAt = DateTime.Now
};
Console.WriteLine($"Original entity: {original})");
Console.WriteLine();

string json = original.ToJson();
Console.WriteLine($"JSON:\r\n\t{json}");
Console.WriteLine();

var xml = Json2Xml.Convert(json);
Console.WriteLine($"XML:\r\n\t{xml?.OuterXml}");
Console.WriteLine();

if (xml != null)
{
    var copy = TestClass.FromXml(xml);
    Console.WriteLine($"Copied entity: {copy})");
    Console.WriteLine();
    Console.WriteLine($"Проверка на идентичность: {copy.Equals(original)}");
}
else
{
    Console.WriteLine("Ошибка конвертирования.");
}