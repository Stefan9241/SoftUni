using System;

namespace _2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double recInSecounds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecoundForOneMeter = double.Parse(Console.ReadLine());

            double distanceGeorgeClimb = timeInSecoundForOneMeter * distanceInMeters;
            double timesHeSlowedDown = Math.Floor(distanceInMeters / 50);
            double totalTime = distanceGeorgeClimb + timesHeSlowedDown * 30;
            if (totalTime < recInSecounds)
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(recInSecounds - totalTime):f2} seconds slower.");
            }
        }
    }
}
