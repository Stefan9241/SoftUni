using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            double avgSpeed = double.Parse(Console.ReadLine());
            double literFor100km = double.Parse(Console.ReadLine());

            double totalDistance = 384400 * 2;
            double timeNeeded = Math.Ceiling(totalDistance / avgSpeed);
            double resultTime = timeNeeded + 3;
            double fuel = (literFor100km * totalDistance) / 100;

            Console.WriteLine($"{resultTime}");
            Console.WriteLine($"{fuel}");

        }
    }
}
