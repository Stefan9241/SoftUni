using System;

namespace Реколта
{
    class Program
    {
        static void Main(string[] args)
        {
            int Xvineyard = int.Parse(Console.ReadLine());
            double Ygrape = double.Parse(Console.ReadLine());
            int ZneedWine = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());

            double totalGrape = Xvineyard * Ygrape;
            double wine = 0.40 * totalGrape / 2.5;

            if (wine < ZneedWine)
            {
                double litersNeeded = Math.Floor(ZneedWine - wine);
                Console.WriteLine($"It will be a tough winter! More {litersNeeded} liters wine needed.");
            }
            else
            {
                double totalWine = Math.Floor(wine);
                Console.WriteLine($"Good harvest this year! Total wine: {totalWine} liters.");
                double litersLeft = Math.Ceiling(wine - ZneedWine);
                double litersPerPerson = Math.Ceiling(litersLeft / numberWorkers);
                Console.WriteLine($"{litersLeft} liters left -> {litersPerPerson} liters per person.");
            }
        }
    }
}
