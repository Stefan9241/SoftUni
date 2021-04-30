using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            double daysPirating = double.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPLunder = 0;
            for (int i = 1; i <= daysPirating; i++)
            {
                totalPLunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    double additionalPlunder = dailyPlunder / 2;
                    totalPLunder += additionalPlunder;
                }
                if (i % 5 == 0)
                {
                    double minusPlunder = totalPLunder * 0.30;
                    totalPLunder -= minusPlunder;
                }
                
            }
            if (totalPLunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPLunder:f2} plunder gained.");
            }
            else
            {
                double percentagePlunder = totalPLunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentagePlunder:f2}% of the plunder.");
            }
        }
    }
}
