using System;
using System.Linq;

namespace _02.KnightOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = print => Console.WriteLine($"Sir {print}");


            Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => print(x));
        }
    }
}
