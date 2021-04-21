using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSecForOneM = double.Parse(Console.ReadLine());
            double distanceToSwim = distance * timeInSecForOneM;
            double addedTime = Math.Floor(distance / 15) * 12.5;
            double totalTime = distanceToSwim + addedTime;
            if ( totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {Math.Abs(totalTime):F2} seconds.");
            }
            else
            {
                double notEnough = record - totalTime;
                Console.WriteLine($"No, he failed! He was {Math.Abs(notEnough):F2} seconds slower.");
            }
        }
    }
}
