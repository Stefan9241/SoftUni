using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double people = double.Parse(Console.ReadLine());
            double priceForOne = double.Parse(Console.ReadLine());
            
            double outfitPrice = people * priceForOne;
            double decor = budget * 0.10;
            if (people >= 150)
            {
                outfitPrice -= outfitPrice * 0.10;
            }
            
            double totalBudget = outfitPrice + decor;
            double result = budget - totalBudget;
            if (totalBudget <= budget)
            {
                
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {result:F2} leva left.");
            }
            else
            {
                
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(result):F2} leva more.");

            }
        }
    }
}
