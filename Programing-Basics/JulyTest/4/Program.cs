using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            double numBalls = double.Parse(Console.ReadLine());
            double redCounter = 0;
            double orangeCounter = 0;
            double yellowCounter = 0;
            double whiteCounter = 0;
            double blackCounter = 0;
            double otherCounter = 0;
            double totalPoints = 0;
            for (int i = 0; i < numBalls; i++)
            {
                string balls = Console.ReadLine();
                if (balls == "red")
                {
                    redCounter++;
                    totalPoints += 5;
                }
                else if (balls == "orange")
                {
                    orangeCounter++;
                    totalPoints += 10;
                }
                else if (balls == "yellow")
                {
                    yellowCounter++;
                    totalPoints += 15;
                }
                else if (balls == "white")
                {
                    whiteCounter++;
                    totalPoints += 20;
                }
                else if (balls == "black")
                {
                    blackCounter++;
                    totalPoints /= 2;
                }
                else
                {
                    otherCounter++;
                }
            }
            Console.WriteLine($"Total points: {Math.Floor(totalPoints)}");
            Console.WriteLine($"Points from red balls: {redCounter}");
            Console.WriteLine($"Points from orange balls: {orangeCounter}");
            Console.WriteLine($"Points from yellow balls: {yellowCounter}");
            Console.WriteLine($"Points from white balls: {whiteCounter}");
            Console.WriteLine($"Other colors picked: {otherCounter}");
            Console.WriteLine($"Divides from black balls: {blackCounter}");
        }
    }
}
