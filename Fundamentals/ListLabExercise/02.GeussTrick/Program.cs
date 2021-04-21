using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GeussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();
            int counter = input.Count / 2;

            for (int i = 0; i < counter; i++)
            {
                input[i] += input[input.Count - 1];
                input.Remove(input[input.Count - 1]);
            }
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
