using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]]++;
                }
                else
                {
                    counts.Add(numbers[i], 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
