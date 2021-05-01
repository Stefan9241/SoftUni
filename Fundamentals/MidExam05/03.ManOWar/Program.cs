using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> warShip = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxHp = int.Parse(Console.ReadLine());
            int needRepairCount = 0;

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Retire")
            {
                if (commands[0] == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int dmg = int.Parse(commands[2]);
                    if (index < 0 || index >= warShip.Count)
                    {
                        commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        warShip[index] -= dmg;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }

                else if (commands[0] == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int dmg = int.Parse(commands[3]);
                    if (startIndex >= 0 && startIndex <= pirateShip.Count - 1
                        && endIndex >= 0 && endIndex <= pirateShip.Count - 1)
                    {
                        for (int j = startIndex; j <= endIndex; j++)
                        {
                            pirateShip[j] -= dmg;
                            if (pirateShip[j] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }

                else if (commands[0] == "Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);
                    if (index < 0 || index >= pirateShip.Count)
                    {
                        commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHp)
                        {
                            pirateShip[index] = maxHp;
                        }
                    }
                }

                else if (commands[0] == "Status")
                {
                    double twentyPercent = maxHp * 0.20;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < twentyPercent)
                        {
                            needRepairCount++;
                        }
                    }
                    Console.WriteLine($"{needRepairCount} sections need repair.");
                    needRepairCount = 0;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            int pirateShipSum = pirateShip.Sum();
            int warShipSum = warShip.Sum();
            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }
    }
}
