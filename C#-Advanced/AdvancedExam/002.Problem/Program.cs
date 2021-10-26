using System;

namespace _002.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            int[] white = new int[2];
            int[] black = new int[2];

            char[] colName = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j] == 'w')
                    {
                        white[0] = i;
                        white[1] = j;
                    }

                    if (line[j] == 'b')
                    {
                        black[0] = i;
                        black[1] = j;
                    }

                    matrix[i, j] = line[j];
                }
            }

            ;
            while (true)
            {
                if (IsValidCoordinate(white[0] - 1, white[1] - 1))
                {
                    if (matrix[white[0] - 1, white[1] - 1] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {colName[white[1] - 1]}{8 - (white[0] - 1)}.");
                        break;
                    }
                }

                if (IsValidCoordinate(white[0] - 1, white[1] + 1))
                {
                    if (matrix[white[0] - 1, white[1] + 1] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {colName[white[1] + 1]}{8 - (white[0] - 1)}.");
                        break;
                    }
                }
                if (white[0] - 1 >= 0)
                {
                    matrix[white[0], white[1]] = '-';
                    matrix[white[0] - 1, white[1]] = 'w';
                    white[0] -= 1;

                    if (white[0] == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {colName[white[1]]}{8 - white[0]}.");
                        break;
                    }
                }

                if (IsValidCoordinate(black[0] + 1, black[1] - 1))
                {
                    if (matrix[black[0] + 1, black[1] - 1] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {colName[black[1] - 1]}{8 - (black[0] + 1)}.");
                        break;
                    }
                }

                if (IsValidCoordinate(black[0] + 1, black[1] + 1))
                {
                    if (matrix[black[0] + 1, black[1] + 1] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {colName[black[1] + 1]}{8 - (black[0] + 1)}.");
                        break;
                    }
                }

                if (black[0] + 1 < 8)
                {
                    matrix[black[0], black[1]] = '-';
                    matrix[black[0] + 1, black[1]] = 'b';
                    black[0] += 1;

                    if (black[0] == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colName[black[1]]}{8 - black[0]}.");
                        break;
                    }
                }
            }
        }

        private static bool IsValidCoordinate(int row, int col)
        {
            return row >= 0 && col >= 0 && row < 8 && col < 8;
        }
    }
}
