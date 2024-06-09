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
            Action<int> currentOperationInt = (int x) => calc.Add(x);
            Action<double> currentOperationDouble = (double x) => calc.Add(x);
            var aliasesInt = new Dictionary<string, Action<int>>()
            {
                { "+", (int x) => calc.Add(x)},
                { "-", (int x) => calc.Sub(x)},
                { "*", (int x) => calc.Mul(x)},
                { "/", (int x) => calc.Div(x)}
            };
            var aliasesDouble = new Dictionary<string, Action<double>>()
            {
                { "+", (double x) => calc.Add(x)},
                { "-", (double x) => calc.Sub(x)},
                { "*", (double x) => calc.Mul(x)},
                { "/", (double x) => calc.Div(x)}
            };

            while (true)
            {
                string? command = Console.ReadLine();
                if (command != null)
                {
                    command = command.ToLower();
                    if (command.Equals("c")) calc.CancelLast();
                    else if (command.Equals("e")) break;
                    else if (aliasesInt.ContainsKey(command)) 
                    {
                        currentOperationInt = aliasesInt[command];
                        currentOperationDouble = aliasesDouble[command];
                    }
                    else if (int.TryParse(command, out int intValue))
                    {
                        currentOperationInt(intValue);
                    }
                    else if (double.TryParse(command, out double doubleValue))
                    {
                        currentOperationDouble(doubleValue);
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