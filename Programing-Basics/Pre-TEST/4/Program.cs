using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCats = int.Parse(Console.ReadLine());
            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            double totalFoodGrams = 0;
            for (int i = 0; i < numCats; i++)
            {
                double gramPerDay = double.Parse(Console.ReadLine());
                totalFoodGrams += gramPerDay;
                if (gramPerDay >= 100 && gramPerDay < 200)
                {
                    group1++;
                }
                else if (gramPerDay >= 200 && gramPerDay < 300)
                {
                    group2++;
                }
                else if (gramPerDay >= 300 && gramPerDay < 400)
                {
                    group3++;
                }
            }
            double kgFood = totalFoodGrams / 1000;
            double priceForFood = kgFood * 12.45;

            Console.WriteLine($"Group 1: {group1} cats.");
            Console.WriteLine($"Group 2: {group2} cats.");
            Console.WriteLine($"Group 3: {group3} cats.");
            Console.WriteLine($"Price for food per day: {priceForFood:f2} lv.");
        }
    }
}
