using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<double, List<double>>();
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    dict[input[i]].Add(input[i]);
                }
                else
                {
                    dict.Add(input[i], new List<double>());
                    dict[input[i]].Add(input[i]);
                }
            }

            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} - {number.Value.Count} times");
            }
        }
    }
}
