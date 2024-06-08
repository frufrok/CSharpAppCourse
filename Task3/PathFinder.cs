using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task3
{
    public class PathFinder
    {
        public static int HasExit(int startI, int startJ, int[,] l)
        {
            LabyrinthHasExit(l, startI, startJ, out HashSet<(int, int)> exits);
            return exits.Count;
        }
        public static bool LabyrinthHasExit(int[,] labyrinth, int i, int j, out HashSet<(int, int)> exits)
        {
            exits = [];
            HashSet <(int, int)> verified = [];
            FindRootRecursive(labyrinth, i, j, ref exits, ref verified);
            return exits.Count > 0;
        }
        private static void FindRootRecursive(int[,] labyrinth, int i, int j, ref HashSet<(int, int)> exits, ref HashSet<(int, int)> verified)
        {
            if (!verified.Contains((i, j)))
            {
                verified.Add((i, j));
                if (IsExit(labyrinth, i, j))
                {
                    exits.Add((i, j));
                }
                else if (IsPath(labyrinth, i, j))
                {
                    FindRootRecursive(labyrinth, i - 1, j, ref exits, ref verified);
                    FindRootRecursive(labyrinth, i + 1, j, ref exits, ref verified);
                    FindRootRecursive(labyrinth, i, j - 1, ref exits, ref verified);
                    FindRootRecursive(labyrinth, i, j + 1, ref exits, ref verified);
                }
            }
        
        }
        private static bool IsPath(int[,] labyrinth, int i, int j)
        {
            return i >= 0 && j >= 0 && i < labyrinth.GetLength(0) && j < labyrinth.GetLength(1) && labyrinth[i, j] == 0;
        }
        private static bool IsExit(int[,] labyrinth, int i, int j)
        {
            return IsPath(labyrinth, i, j) && (i == 0 || j == 0 || i == labyrinth.GetLength(0) - 1 || j == labyrinth.GetLength(1) - 1);
        }
    }
}