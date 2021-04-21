using System;

namespace _C_към_градуси__F
{
    class Program
    {
        static void Main(string[] args)
        {
            double c = double.Parse(Console.ReadLine());

            double F = c * 1.8 + 32;
            Console.WriteLine($"{F:f2}");
        }
    }
}
