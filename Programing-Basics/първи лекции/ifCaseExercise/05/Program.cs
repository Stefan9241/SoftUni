using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double totalBudget = 0;

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    totalBudget = budget * 0.30;
                    Console.WriteLine($"Camp - {totalBudget:F2}");
                }
                else if (season == "winter")
                {
                    totalBudget = budget * 0.70;
                    Console.WriteLine($"Hotel - {totalBudget:f2}");
                }
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    totalBudget = budget * 0.40;
                    Console.WriteLine($"Camp - {totalBudget:f2}");
                }
                else if (season == "winter")
                {
                    totalBudget = budget * 0.80;
                    Console.WriteLine($"Hotel - {totalBudget:f2}");
                }
            }
            else if (budget > 1000)
            {
                Console.WriteLine("Somewhere in Europe");
                if (season == "summer")
                {
                    totalBudget = budget * 0.90;
                    Console.WriteLine($"Hotel - {totalBudget:f2}");
                }
                else if (season == "winter")
                {
                    totalBudget = budget * 0.90;
                    Console.WriteLine($"Hotel - {totalBudget:f2}");
                }
            }
        }
    }
}
