using System;
using System.Linq;

namespace _01.SortEvenNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int,bool> filter = (a,b) => a % b == 0;

            nums = nums.Where(x => filter(x, 2)).ToArray();
            nums = nums.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
