using System;

namespace Поспаливата_котка_Том
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysRest = int.Parse(Console.ReadLine());
            int tomNeeds = 30000;
            int workDayMins = 63;
            int weekEnd = 127;

            int workDays = 365 - daysRest;
            int playTime = workDayMins * workDays + daysRest * weekEnd;
            int totalMins = tomNeeds - playTime;
            int hours = Math.Abs(totalMins / 60);
            int mins = Math.Abs(totalMins % 60);
            if (playTime > tomNeeds)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {mins} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {mins} minutes less for play");
            }


        }
    }
}
