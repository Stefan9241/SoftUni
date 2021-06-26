using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> comparator = (a, b) => (a % 2 == 0 && b % 2 != 0) ? -1 
            : (a % 2 != 0 && b % 2 == 0) ? 1 
            : a.CompareTo(b);
            Array.Sort(input, new Comparison<int>(comparator));
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
