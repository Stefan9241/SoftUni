using System;

namespace __Магазин_за_цветя
{
    class Program
    {
        static void Main(string[] args)
        {
            int numChrysanthemums = int.Parse(Console.ReadLine());
            int numRoses = int.Parse(Console.ReadLine());
            int numTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char yORn = char.Parse(Console.ReadLine());

            double sumChrysanthemums = 0;
            double sumRoses = 0;
            double sumTulips = 0;

            if (season == "Spring")
            {
                sumChrysanthemums += 2.00 * numChrysanthemums;
                sumRoses += 4.10 * numRoses;
                sumTulips += 2.50 * numTulips;
            }
            else if (season == "Summer")
            {
                sumChrysanthemums += 2.00 * numChrysanthemums;
                sumRoses += 4.10 * numRoses;
                sumTulips += 2.50 * numTulips;
            }
            else if (season == "Autumn")
            {
                sumChrysanthemums += 3.75 * numChrysanthemums;
                sumRoses += 4.50 * numRoses;
                sumTulips += 4.15 * numTulips;
            }
            else if (season == "Winter")
            {
                sumChrysanthemums += 3.75 * numChrysanthemums;
                sumRoses += 4.50 * numRoses;
                sumTulips += 4.15 * numTulips;
            }

            double totalSum = sumTulips + sumRoses + sumChrysanthemums;
            if (yORn == 'Y')
            {
                totalSum += totalSum * 0.15;
            }

            if (numTulips > 7 && season == "Spring")
            {
                totalSum -= totalSum * 0.05;
            }

            if (numRoses >= 10 && season == "Winter")
            {
                totalSum = totalSum - totalSum * 0.10;
            }
            if (numRoses + numChrysanthemums + numTulips > 20)
            {
                totalSum -= totalSum * 0.20;
            }
            Console.WriteLine($"{totalSum + 2:F2}");
        }
    }
}
