using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse)
                                        .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                int nextIndex = 0;
                if (i + 1 > input.Count - 1)
                {
                    break;
                }
                else
                {
                    nextIndex = i + 1;
                }

                if (input[i] == input[nextIndex])
                {
                    input[i] += input[nextIndex];
                    input.RemoveAt(i + 1);
                    i = -1;
                }

            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}
