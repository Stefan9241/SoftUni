using System;

namespace Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000M;

            Console.WriteLine($"{kilometers:F2}");

        }
    }
}
