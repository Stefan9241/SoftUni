using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double budget = 0;
            while (command != "Start")
            {
                double currentCoins = double.Parse(command);
                if (currentCoins == 0.1 || currentCoins == 0.2 || currentCoins == 0.5 || currentCoins == 1 || currentCoins == 2)
                {
                    budget += currentCoins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoins}");
                }
                command = Console.ReadLine();
            }
            string newCommand = Console.ReadLine();
            while (newCommand != "End")
            {
                if (newCommand == "Nuts")
                {
                    budget -= 2;
                    if (budget < 0)
                    {
                        budget += 2;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {newCommand.ToLower()}");
                    }
                }
                else if (newCommand == "Water")
                {
                    budget -= 0.7;
                    if (budget < 0)
                    {
                        budget += 0.7;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {newCommand.ToLower()}");
                    }
                }
                else if (newCommand == "Crisps")
                {
                    budget -= 1.5;
                    if (budget < 0)
                    {
                        budget += 1.5;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {newCommand.ToLower()}");
                    }
                }
                else if (newCommand == "Soda")
                {
                    budget -= 0.8;
                    if (budget < 0)
                    {
                        budget += 0.8;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {newCommand.ToLower()}");
                    }
                }
                else if (newCommand == "Coke")
                {
                    budget -= 1;
                    if (budget < 0)
                    {
                        budget += 1;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {newCommand.ToLower()}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                    newCommand = Console.ReadLine();
            }
            Console.WriteLine($"Change: {budget:F2}");
        }
    }
}
