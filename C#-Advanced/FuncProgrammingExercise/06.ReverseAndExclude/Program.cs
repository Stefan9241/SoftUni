using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> filter = (x, y) => x % y != 0;

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numToDevide = int.Parse(Console.ReadLine());

            input = input.Reverse().ToArray();

            input = input.Where(x => filter(x, numToDevide)).ToArray();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
