using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> evenPred = x => x % 2 == 0;
            Predicate<int> oddPred = x => x % 2 != 0;

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string filter = Console.ReadLine();
            List<int> list = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                list.Add(i);
            }
            switch (filter)
            {
                case "odd":
                    list = list.Where(x => oddPred(x)).ToList();
                    break;
                case "even":
                    list = list.Where(x => evenPred(x)).ToList();
                    break;
            }

            Console.WriteLine(string.Join(" ",list));
        }
    }
}
