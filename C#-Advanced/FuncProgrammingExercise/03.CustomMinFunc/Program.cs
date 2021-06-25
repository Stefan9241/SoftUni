using System;
using System.Linq;

namespace _03.CustomMinFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> result = x => x.Min();

            Console.WriteLine(result(nums));
        }
    }
}
