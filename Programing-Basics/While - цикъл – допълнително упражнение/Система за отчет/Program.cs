using System;

namespace Система_за_отчет
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumNeeded = double.Parse(Console.ReadLine());
            int counterCash = 0;
            int counterCard = 0;
            double cashSum = 0;
            double cardSum = 0;
            double sum = 0;
            int counter = 0;
            string text = Console.ReadLine();
            while (text != "End")
            {
                double currentMoney = double.Parse(text);
                counter++;
                if (counter % 2 != 0)
                {
                    counterCash++;
                    if (currentMoney > 100)
                    {
                        counterCash--;
                        if (counterCash < 0)
                        {
                            counterCash = 0;
                        }
                        Console.WriteLine("Error in transaction!");
                        text = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                    }
                    cashSum += currentMoney;
                    sum += currentMoney;
                }
                else if (counter % 2 == 0)
                {
                    counterCard++;
                    if (currentMoney < 10)
                    {
                        counterCard--;
                        if (counterCard < 0)
                        {
                            counterCard = 0;
                        }
                        Console.WriteLine("Error in transaction!");
                        text = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");                        
                    }
                    cardSum += currentMoney;
                    sum += currentMoney;
                }
                if (sum >= sumNeeded)
                {
                    Console.WriteLine($"Average CS: {cashSum / counterCash:F2}");
                    Console.WriteLine($"Average CC: {cardSum / counterCard:F2}");
                    Environment.Exit(0);
                }
                text = Console.ReadLine();
            }
            Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}
