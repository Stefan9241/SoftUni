using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int numHours = int.Parse(Console.ReadLine());
            double totalSum = 0;
            double sumDay = 0;
            for (int days = 1; days <= numDays; days++)
            {
                for (int hours = 1; hours <= numHours; hours++)
                {
                    if (days % 2 ==0 && hours % 2 != 0)
                    {
                        sumDay+= 2.50;
                        totalSum += 2.50;
                    }
                    else if (days % 2 != 0 && hours % 2 == 0)
                    {
                        sumDay += 1.25;
                        totalSum += 1.25;
                    }
                    else
                    {
                        sumDay += 1;
                        totalSum += 1;
                    }
                }
                Console.WriteLine($"Day: {days} - {sumDay:F2} leva");
                sumDay = 0;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");

        }
    }
}
