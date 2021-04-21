using System;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int liliAge = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int toys = 0;
            double savedMoney = 0;
            double birthDayMoney = 10;
            for (int i = 1; i <= liliAge; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += birthDayMoney;
                    birthDayMoney += 10;
                    savedMoney -= 1;
                }
                else
                {
                    toys++;
                }
            }
            savedMoney += toys * toysPrice;
            if (savedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {savedMoney - washingMachinePrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - savedMoney:f2}");
            }

        }
    }
}
