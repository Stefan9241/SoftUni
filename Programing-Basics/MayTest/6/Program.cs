using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int numHours = int.Parse(Console.ReadLine());
            double priceTotal = 0;
            for (int days = 1; days <= numDays; days++)
            {
                double price = 0;
                for (int hours = 1; hours <= numHours; hours++)
                {
                    if (days % 2 == 0 && hours % 2 != 0)
                    {
                        price += 2.50;
                    }
                    else if (days % 2 != 0 && hours % 2 == 0)
                    {
                        price += 1.25;
                    }
                    else
                    {
                        price += 1;
                    }
                    
                }
                Console.WriteLine($"Day: {days} - {price:f2} leva");
                priceTotal += price;
            }
            Console.WriteLine($"Total: {priceTotal:f2} leva");
        }
    }
}
