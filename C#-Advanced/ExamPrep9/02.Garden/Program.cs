using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndColNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowAndColNumbers[0], rowAndColNumbers[1]];

            var list = new List<int[]>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                string[] positionToPlant = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int positionRow = int.Parse(positionToPlant[0]);
                int positionCol = int.Parse(positionToPlant[1]);
                if (positionRow < 0
                 || positionRow >= rowAndColNumbers[0]
                 || positionCol >= rowAndColNumbers[1]
                 || positionCol < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                list.Add(new int[] { positionRow, positionCol });
            }

            foreach (var info in list)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[info[0], i] != 0)
                    {
                        matrix[info[0], i]++;
                        matrix[i, info[1]]++;
                    }
                    else
                    {
                        matrix[info[0], i] = 1;
                        matrix[i, info[1]] = 1;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
