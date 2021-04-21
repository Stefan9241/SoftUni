using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceRocket = double.Parse(Console.ReadLine());
            int numRockets = int.Parse(Console.ReadLine());
            int numSneackers = int.Parse(Console.ReadLine());

            double priceSneackers = priceRocket / 6;
            double total = priceRocket * numRockets + priceSneackers * numSneackers;
            double other = total * 0.20;
            total += other;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(total/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(total*7/8)}");
        }
    }
}
