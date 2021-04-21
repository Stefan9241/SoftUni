using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            if (min >= 45)
            {
                hour += 1;
                min = (min + 15) % 60;
            }
            else if (min >= 0)
            {
                min = min + 15;
            }
            if(hour == 24)
            {
                hour = 0;
            }
            Console.WriteLine($"{hour}:{min:D2}");
        }
    }
}
