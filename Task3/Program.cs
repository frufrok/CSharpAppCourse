using Task3;

int[,] labyrinth = new int[,]
{
{1, 1, 1, 1, 1, 1, 1 },
{1, 0, 0, 0, 0, 0, 1 },
{1, 0, 1, 1, 1, 0, 1 },
{0, 0, 0, 0, 1, 0, 0 },
{1, 1, 0, 0, 1, 1, 1 },
{1, 1, 1, 0, 1, 1, 1 },
{1, 1, 1, 0, 1, 1, 1 }
};

Console.WriteLine($"Всего выходов: {PathFinder.HasExit(1, 4, labyrinth)}");
if (PathFinder.LabyrinthHasExit(labyrinth, 1, 4, out HashSet<(int, int)> exits))
{
    Console.WriteLine("Не торчу два года, но найду тебе шикарный выход:");
    foreach ((int, int) pair in exits)
    {
        Console.WriteLine($"{pair.Item1} : {pair.Item2}");
    }
}