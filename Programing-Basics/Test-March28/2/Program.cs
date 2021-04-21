using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int minWalk = int.Parse(Console.ReadLine());
            int numWalks = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            double caloriesBurn = minWalk * numWalks * 5;
            double minimumCalories = calories / 2;
            if (caloriesBurn >= minimumCalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurn}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurn}.");
            }
        }
    }
}
