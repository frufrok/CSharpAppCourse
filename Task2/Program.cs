using Task2;


Console.WriteLine("Числа до 20 в битах:");
for (byte i = 0; i < 20; i++)
{
    Bits bits = new Bits(i);
    Console.WriteLine(bits.GetBitsString());
}
Console.WriteLine();


Console.WriteLine("Исходное число:");
Bits myBits = new Bits(0);
void demo1(string message, Action action)
{
    Console.WriteLine(message);
    Console.Write(myBits.GetBitsString());
    action();
    Console.Write(" -> ");
    Console.WriteLine(myBits.GetBitsString());
}
demo1("Меняем нулевой бит:", () => myBits.SetBitByIndex(0, true));
demo1("Меняем первый бит:", () => myBits.SetBitByIndex(1, true));
demo1("Меняем третий бит:", () => myBits.SetBitByIndex(3, true));
demo1("Меняем третий бит обратно:", () => myBits.SetBitByIndex(3, false));


Devices devices = new Devices();
for (int i = 0; i < 4; i++)
{
    devices.DevicesList.Add(new Device());
}

Console.WriteLine();
Bits controlBits = new Bits(15);
Console.WriteLine($"Control bits: {controlBits.ToString()}");
devices.TurnAll(controlBits);
Console.WriteLine("Результат:");
Console.WriteLine(devices);

Console.WriteLine();
controlBits = new Bits(13);
Console.WriteLine($"Control bits: {controlBits.ToString()}");
devices.TurnAll(controlBits);
Console.WriteLine("Результат:");
Console.WriteLine(devices);
