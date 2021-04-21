using System;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Минути на контролата – цяло число в интервала[0…59]
            //Секунди на контролата – цяло число в интервала[0…59]
            //Дължината на улея в метри – реално число в интервала[0.00…50000]
            //Секунди за изминаване на 100 метра – цяло число в интервала[0…1000

            int min = int.Parse(Console.ReadLine());
            int sec = int.Parse(Console.ReadLine());
            double lenghtInMeters = double.Parse(Console.ReadLine());
            int secFor100m = int.Parse(Console.ReadLine());

            int totalSecsNeed = min * 60 + sec;
            double decreseTime = lenghtInMeters / 120;
            double totalDecTime = decreseTime * 2.5;
            double result = (lenghtInMeters / 100) * secFor100m - totalDecTime;
            if (totalSecsNeed >= result)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {result:F3}.");
            }
            else
            {
                double diff = Math.Abs(totalSecsNeed - result);
                Console.WriteLine($"No, Marin failed! He was {diff:f3} second slower.");
            }
        }
    }
}
