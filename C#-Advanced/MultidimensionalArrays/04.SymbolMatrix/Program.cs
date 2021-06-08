using System;

namespace _04.SymbolMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[i] = input;
            }

            char findSymbol = char.Parse(Console.ReadLine());

            bool trueOrFalse = false;
            int rowTrue = 0;
            int colTrue = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == findSymbol)
                    {
                        trueOrFalse = true;
                        rowTrue = row;
                        colTrue = col;
                        break;
                    }
                }
                if (trueOrFalse)
                {
                    break;
                }
            }

            if (trueOrFalse)
            {
                Console.WriteLine($"({rowTrue}, {colTrue})");
            }
            else
            {
                Console.WriteLine($"{findSymbol} does not occur in the matrix ");
            }
        }
    }
}
