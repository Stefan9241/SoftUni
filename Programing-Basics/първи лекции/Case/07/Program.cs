using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (day == "Monday" && hour >=10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else if (day == "Tuesday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else  if (day == "Wednesday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else if (day == "Thursday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else if  (day == "Friday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else if (day == "Saturday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
