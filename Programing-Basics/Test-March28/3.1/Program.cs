using System;

namespace _3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double priceForMonth = 0;
            switch (sex)
            {
                case 'm':
                    switch (sport)
                    {
                        case "Gym":
                            priceForMonth = 42;
                            break;
                        case "Boxing":
                            priceForMonth = 41;
                            break;
                        case "Yoga":
                            priceForMonth = 45;
                            break;
                        case "Zumba":
                            priceForMonth = 34;
                            break;
                        case "Dances":
                            priceForMonth = 51;
                            break;
                        case "Pilates":
                            priceForMonth = 39;
                            break;
                    }
                    break;
                case 'f':
                    switch (sport)
                    {
                        case "Gym":
                            priceForMonth = 35;
                            break;
                        case "Boxing":
                        case "Pilates":
                            priceForMonth = 37;
                            break;
                        case "Yoga":
                            priceForMonth = 42;
                            break;
                        case "Zumba":
                            priceForMonth = 31;
                            break;
                        case "Dances":
                            priceForMonth = 53;
                            break;
                    }
                    break;
            }
            if (age <= 19)
            {
                priceForMonth -= priceForMonth * 0.20;
            }
            if (budget >= priceForMonth)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                double diff = Math.Abs(budget - priceForMonth);
                Console.WriteLine($"You don't have enough money! You need ${diff:f2} more.");
            }
        }
    }
}
