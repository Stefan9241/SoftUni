using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            food = food * 1000;
            while (command != "Adopted")
            {
                int minusFood = int.Parse(command);
                food -= minusFood;
                command = Console.ReadLine();
            }
            if (food >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {food} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(food)} grams more.");
            }
        }
    }
}
