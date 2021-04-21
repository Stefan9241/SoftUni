using System;

namespace Домашни_любимци
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double forDog = double.Parse(Console.ReadLine());
            double forCat = double.Parse(Console.ReadLine());
            double forTurtle = double.Parse(Console.ReadLine());

            double foodNeed = numDays * forCat + numDays * forDog + (numDays * forTurtle / 1000);
            if (foodNeed <= foodLeft)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - foodNeed)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodNeed - foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
