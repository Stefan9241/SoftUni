using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            double moneyWon = 0;
            double daysWon = 0;
            double daysLost = 0;
            for (int i = 0; i < numDays; i++)
            {
                double counterWonToday = 0;
                double counterLostToday = 0;
                double moneyWonToday = 0;
              
                string command = Console.ReadLine();
                while (command != "Finish")
                {
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        moneyWonToday += 20;
                        counterWonToday++;
                    }
                    else
                    {
                        counterLostToday++;
                    }
                    command = Console.ReadLine();
                }
                if (counterLostToday < counterWonToday)
                {
                    moneyWonToday += moneyWonToday * 0.10;
                    moneyWon += moneyWonToday;
                    daysWon++;
                }
                else
                {
                    moneyWon += moneyWonToday;
                    daysLost++;
                }
            }
            if (daysWon > daysLost)
            {
                moneyWon += moneyWon * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {moneyWon:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {moneyWon:f2}");
            }
        }
    }
}
