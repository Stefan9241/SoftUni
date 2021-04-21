using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaci = int.Parse(Console.ReadLine());
            int numEggShells = int.Parse(Console.ReadLine());
            int kgOfCookies = int.Parse(Console.ReadLine());

            double priceKozunaci = numKozunaci * 3.20;
            double priceEggs = numEggShells * 4.35;
            double priceCoockies = kgOfCookies * 5.40;
            double priceForPaint = numEggShells * 12 * 0.15;

            double sum = priceCoockies + priceEggs + priceForPaint + priceKozunaci;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
