using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaci = int.Parse(Console.ReadLine());
            string winnerName = "";
            int MaxPoints = int.MinValue;
            for (int i = 0; i < numKozunaci; i++)
            {
                string bakerName = Console.ReadLine();
                string command = Console.ReadLine();
                int currentCount = 0;
                while (command != "Stop")
                {
                    int valuatian = int.Parse(command);
                    currentCount += valuatian;
                    command = Console.ReadLine();
                }
                Console.WriteLine($"{bakerName} has {currentCount} points.");
                if (currentCount > MaxPoints)
                {
                    MaxPoints = currentCount;
                    winnerName = bakerName;
                    Console.WriteLine($"{bakerName} is the new number 1!");
                }
            }
            Console.WriteLine($"{winnerName} won competition with {MaxPoints} points!");
        }
    }
}
