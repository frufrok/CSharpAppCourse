Random random = new Random();
int[] values = new int[20];
for (int i = 0; i < values.Length; i++)
{
    values[i] = random.Next(0, 10);
}

int sum = random.Next(0, 20);
bool flag = false;

Console.WriteLine($"Дан массив чисел: {String.Join(" ", values)}");
Console.WriteLine($"Ищем 3 числа, которые дают в сумме {sum}:");

for (int i = 0; i < values.Length; i++)
{
    if (values[i] <= sum)
    {
        for (int j = i + 1; j < values.Length; j++)
        {
            if (values[i] + values[j] <= sum)
            {
                for (int k = j + 1; k < values.Length; k++)
                {
                    if (values[i] + values[j] + values [k] == sum)
                    {
                        Console.WriteLine($"{values[i]} + {values[j]} + {values[k]} = {sum}");
                        flag = true;
                    }
                }
            }
        }
    }
}

if (!flag) Console.WriteLine("Нет решения");
