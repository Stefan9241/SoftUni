using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneySheHas = double.Parse(Console.ReadLine());
            int days = 0;
            int spendDays = 0;
            while (true)
            {
                days++;
                string text = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (text == "spend")
                {
                    moneySheHas -= money;
                    spendDays++;
                    if (moneySheHas < 0)
                    {
                        moneySheHas = 0;
                    }
                    if (spendDays >= 5)
                    {
                        break;
                    }
                }
                else if (text == "save")
                {
                    moneySheHas += money;
                    spendDays = 0;
                    if(moneyNeeded <= moneySheHas)
                    {
                        break;
                    }
                }
            }
            if (moneyNeeded <= moneySheHas)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{days}");
            }
            
        }
    }
}
