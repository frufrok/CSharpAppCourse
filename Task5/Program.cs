using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICalc calc = new Calc();
            calc.GotResult += PrintResult;
            Console.WriteLine("Калькулятор запущен. Отмена последнего действия - 'c', выход - 'e'.");
            Action<int> currentOperation = (int x) => calc.Add(x);
            var aliases = new Dictionary<string, Action<int>>()
            {
                { "+", (int x) => calc.Add(x)},
                { "-", (int x) => calc.Sub(x)},
                { "*", (int x) => calc.Mul(x)},
                { "/", (int x) => calc.Div(x)}
            };

            while (true)
            {
                string? command = Console.ReadLine();
                if (command != null)
                {
                    command = command.ToLower();
                    if (command.Equals("c")) calc.CancelLast();
                    else if (command.Equals("e")) break;
                    else if (aliases.ContainsKey(command)) currentOperation = aliases[command];
                    else if (int.TryParse(command, out int value))
                    {
                        currentOperation(value);
                    }
                    else Console.WriteLine("Недопустимый аргумент.");
                }
            }
            Console.WriteLine("Работа программы завершена.");
        }

        private static void PrintResult(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Console.WriteLine($"Результат: {((ICalc)sender).GetResult()}");
            }
        }
    }
}