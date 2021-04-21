using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFishers = int.Parse(Console.ReadLine());

            double shipPrice = 0;
            switch (season)
            {
                case "Spring":
                    shipPrice = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    shipPrice = 4200;
                    break;
                case "Winter":
                    shipPrice = 2600;
                    break;
            }
            double discount = 0;
            if (numberFishers <= 6)
            {
                discount = 0.10;
            }
            else if (numberFishers >=7 && numberFishers <= 11)
            {
                discount = 0.15;
            }
            else if (numberFishers > 12)
            {
                discount = 0.25;
            }

            double totalPrice = shipPrice - shipPrice * discount;
            double addedDiscount = 0;
            if (numberFishers % 2 ==0 && season != "Autumn")
            {
                addedDiscount = 0.05;
                totalPrice -= totalPrice * addedDiscount;
            }
            if (budget >= totalPrice)
            {
                double leftSum = budget - totalPrice;
                Console.WriteLine($"Yes! You have {leftSum:F2} leva left.");
            }
            else
            {
                double needSum = totalPrice - budget;
                Console.WriteLine($"Not enough money! You need {needSum:F2} leva.");
            }

        }
    }
}
