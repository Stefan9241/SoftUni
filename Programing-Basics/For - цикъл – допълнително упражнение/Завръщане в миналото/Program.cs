using System;

namespace Завръщане_в_миналото
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritMoney = double.Parse(Console.ReadLine());
            int yearHeDies = int.Parse(Console.ReadLine());
            int years = 18;
            
            for (int i = 1800; i <= yearHeDies; i++)
            {
                if (i % 2 ==0)
                {
                    inheritMoney -= 12000;
                }
                else
                {
                    inheritMoney -= 12000 + (50 * years);
                }
                years++;
            }
            if (inheritMoney >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheritMoney:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(inheritMoney):F2} dollars to survive.");
            }
        }
    }
}
