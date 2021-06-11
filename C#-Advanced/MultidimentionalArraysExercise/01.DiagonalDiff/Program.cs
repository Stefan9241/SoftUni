using System;
using System.Linq;

namespace _01.DiagonalDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int primeSum = 0;
            int secSum = 0;
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int i = 0; i < n; i++)
            {
                primeSum += matrix[i, i];
                secSum += matrix[i, n - i - 1];
            }

            Console.WriteLine($"{Math.Abs(primeSum - secSum)}");
        }
    }
}
