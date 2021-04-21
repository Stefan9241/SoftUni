using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLocations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numLocations; i++)
            {
                double expected = double.Parse(Console.ReadLine());
                int numDays = int.Parse(Console.ReadLine());
                double extraction = 0;
                for (int j  = 0; j < numDays; j++)
                {
                    extraction += double.Parse(Console.ReadLine());
                }
                double avgExtraction = extraction / numDays;
                if (avgExtraction >= expected)
                {
                    Console.WriteLine($"Good job! Average gold per day: {avgExtraction:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {expected - avgExtraction:f2} gold.");
                }
            }
        }
    }
}
