using System;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double teamDesi = 0;
            double enemyTeam = 0;
            double win = 0;
            double defeat = 0;
            double gamesTotal = 0;
            while (name != "End of tournaments")
            {
                int gamesCounter = 0;
                int games = int.Parse(Console.ReadLine());
                for (int i = 0; i < games; i++)
                {
                    gamesTotal++;
                    gamesCounter++;
                    teamDesi = int.Parse(Console.ReadLine());
                    enemyTeam = int.Parse(Console.ReadLine());
                    if (teamDesi > enemyTeam)
                    {
                        win++;
                        Console.WriteLine($"Game {gamesCounter} of tournament {name}: win with {teamDesi - enemyTeam} points.");
                    }
                    else
                    {
                        defeat++;
                        Console.WriteLine($"Game {gamesCounter} of tournament {name}: lost with {enemyTeam - teamDesi} points.");
                    }
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{win * 100 / gamesTotal:f2}% matches win");
            Console.WriteLine($"{defeat * 100 / gamesTotal:f2}% matches lost");
        }
    }
}
