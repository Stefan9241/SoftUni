using System;
using System.Linq;

namespace _06.JaggedArrayMani
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] curInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                matrix[i] = curInput;
            }

            for (int i = 0; i < n - 1; i++)
            {
                int row1 = matrix[i].Length;
                int row2 = matrix[i + 1].Length;
                if (row1 == row2)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                    }

                    for (int k = 0; k < matrix[i + 1].Length; k++)
                    {
                        matrix[i + 1][k] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                    for (int k = 0; k < matrix[i + 1].Length; k++)
                    {
                        matrix[i + 1][k] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (command[0] == "Add")
                {
                    if (row >= 0 && row <= matrix.Length - 1 && col >= 0 && col <= matrix[row].Length - 1 && value >= 0)
                    {
                        matrix[row][col] += value;
                    }

                }
                else if (command[0] == "Subtract")
                {
                    if (row >= 0 && row <= matrix.Length - 1 && col >= 0 && col <= matrix[row].Length - 1 && value >= 0)
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }


            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
