using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            double numblerFlowers = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double oneFlower = 0;
            double discount = 0;

            switch (flower)
            {
                case "Roses":
                    oneFlower = 5;
                    break;
                case "Dahlias":
                    oneFlower = 3.80;
                    break;
                case "Tulips":
                    oneFlower = 2.80;
                    break;
                case "Narcissus":
                    oneFlower = 3;
                    break;
                case "Gladiolus":
                    oneFlower = 2.50;
                    break;
            }
            double price = oneFlower * numblerFlowers;
            if (flower == "Roses" && numblerFlowers > 80)
            {
                discount = 0.10;
                price -= price * discount;

            }
            else if (flower == "Dahlias" && numblerFlowers > 90)
            {
                discount = 0.15;
                price -= price * discount;
            }
            else if (flower == "Tulips" && numblerFlowers > 80)
            {
                discount = 0.15;
                price -= price * discount;
            }
            else if (flower == "Narcissus" && numblerFlowers < 120)
            {
                discount = 0.15;
                price += price * discount;
            }
            else if (flower == "Gladiolus" && numblerFlowers < 80)
            {
                discount = 0.20;
                price += price * discount;
            }
            if (budget <= price)
            {
                double needSum = price - budget;
                Console.WriteLine($"Not enough money, you need {needSum:f2} leva more.");
            }
            else if (budget >= price)
            {
                double leftSum = budget - price;
                Console.WriteLine($"Hey, you have a great garden with {numblerFlowers} {flower} and {leftSum:F2} leva left.");
            }
        }
    }
}
