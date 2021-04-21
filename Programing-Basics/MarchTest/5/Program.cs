using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            double numTournaments = double.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            double countWon = 0;
            double pointsWon = 0;
            for (int i = 0; i < numTournaments; i++)
            {
                string whatHappend = Console.ReadLine();
                if (whatHappend == "W")
                {
                    startingPoints += 2000;
                    pointsWon += 2000;
                    countWon++;
                }
                else if (whatHappend == "F")
                {
                    startingPoints += 1200;
                    pointsWon += 1200;
                }
                else
                {
                    startingPoints += 720;
                    pointsWon += 720;
                }
            }

            Console.WriteLine($"Final points: {startingPoints}");
            Console.WriteLine($"Average points: {Math.Floor(pointsWon/ numTournaments)}");
            Console.WriteLine($"{(countWon/numTournaments)* 100:F2}%");
        }
    }
}
