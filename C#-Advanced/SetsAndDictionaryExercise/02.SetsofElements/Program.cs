using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int i = 0; i < input[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                first.Add(number);
            }

            for (int j = 0; j < input[1]; j++)
            {
                int newNumber = int.Parse(Console.ReadLine());
                second.Add(newNumber);
            }
            List<int> numsToPrint = new List<int>();
            foreach (var num in first)
            {
                if (second.Contains(num))
                {
                    numsToPrint.Add(num);
                }
            }

            Console.WriteLine($"{string.Join(" ",numsToPrint)}");
        }
    }
}
