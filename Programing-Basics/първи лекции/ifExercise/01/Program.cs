using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firstTime + secondTime + thirdTime;

            double minutes = totalTime / 60;
            double secounds = totalTime % 60;
            if (secounds < 10)
            {
                Console.WriteLine($"{minutes}:0{secounds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{secounds}");
            }

        }
    }
}
