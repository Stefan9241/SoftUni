using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int command = int.Parse(Console.ReadLine());
                list.Add(command);

            }
            var box = new Box<int>(list);

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            box.SwapMethod(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
