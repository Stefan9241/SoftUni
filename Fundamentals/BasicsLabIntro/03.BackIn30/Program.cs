using System;

namespace _03.BackIn30
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 30;
            if (minutes > 59)
            {
                hours++;
                if (hours == 24)
                {
                    hours = 0;
                }
                minutes -= 60;
            }
            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
