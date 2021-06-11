using System;
using System.Linq;

namespace _02.SqrsInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[inputNums[0], inputNums[1]];
            int count = 0;
            for (int row = 0; row < inputNums[0]; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < inputNums[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row,col] == matrix[row+1,col]
                        && matrix[row,col] == matrix[row,col + 1]
                        && matrix[row,col] == matrix[row+1,col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
