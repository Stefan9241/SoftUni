using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double totalDogFood = 0;
            double totalCatFood = 0;
            double biscuitsEatenGr = 0;
            for (int i = 1; i <= numDays; i++)
            {
                int foodDog = int.Parse(Console.ReadLine());
                int foodCat = int.Parse(Console.ReadLine());
                totalCatFood += foodCat;
                totalDogFood += foodDog;
                if (i % 3 == 0)
                {
                    double biscuits = (foodCat + foodDog) * 0.10;
                    biscuitsEatenGr += biscuits;
                }
            }
            double totalFood = totalDogFood + totalCatFood;
            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsEatenGr)}gr.");
            Console.WriteLine($"{totalFood / food * 100:F2}% of the food has been eaten.");
            Console.WriteLine($"{totalDogFood / totalFood * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalCatFood / totalFood * 100:f2}% eaten from the cat.");
        }
    }
}
