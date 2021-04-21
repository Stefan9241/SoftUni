using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();
            double totalMoney = 0;
            while (money != "NoMoreMoney")
            {
                double currentMoney = double.Parse(money);
                if (currentMoney > 0)
                {
                    Console.WriteLine($"Increase: {currentMoney:f2}");
                    totalMoney += currentMoney;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                money = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalMoney:F2}");
        }
    }
}
