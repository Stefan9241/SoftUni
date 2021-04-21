using System;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string PlayerName = Console.ReadLine();
            int scoreToBeat = 301;
            int successfulShots = 0;
            int unSuccessfulShots = 0;
            string command = Console.ReadLine();
            while (command != "Retire")
            {
                int score = int.Parse(Console.ReadLine());
                if (command == "Single")
                {
                    if (scoreToBeat - score >= 0)
                    {
                        scoreToBeat -= score;
                        successfulShots++;
                    }
                    else
                    {
                        unSuccessfulShots++;
                    }
                }
                else if (command == "Double")
                {
                    if (scoreToBeat - score * 2 >= 0)
                    {
                        scoreToBeat -= score * 2;
                        successfulShots++;
                    }
                    else
                    {
                        unSuccessfulShots++;
                    }
                }
                else if (command == "Triple")
                {
                    if (scoreToBeat - score * 3 >= 0)
                    {
                        scoreToBeat -= score * 3;
                        successfulShots++;
                    }
                    else
                    {
                        unSuccessfulShots++;
                    }
                }
                if (scoreToBeat == 0)
                {
                    Console.WriteLine($"{PlayerName} won the leg with {successfulShots} shots.");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{PlayerName} retired after {unSuccessfulShots} unsuccessful shots.");
        }
    }
}
