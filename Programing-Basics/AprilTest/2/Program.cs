using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Брой гости – цяло число в интервала[1...99]
            //Цена на куверт за един човек – реално число в интервала[0.00 … 99.00]
            //Бюджетът на Деси  – реално число в интервала[0.00 … 9999.00]

            int numGuests = int.Parse(Console.ReadLine());
            double priceEnvelope = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if(numGuests >= 10 && numGuests <= 15)
            {
                priceEnvelope -= priceEnvelope * 0.15;
            }
            else if (numGuests > 15 && numGuests <= 20)
            {
                priceEnvelope -= priceEnvelope * 0.20;
            }
            else if (numGuests > 20)
            {
                priceEnvelope -= priceEnvelope * 0.25;
            }
            double cakePrice = budget * 0.10;
            double sum = cakePrice + priceEnvelope * numGuests;
            if (budget >= sum)
            {
                Console.WriteLine($"It is party time! {budget - sum:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {Math.Abs(budget - sum):F2} leva needed.");
            }
        }
    }
}
