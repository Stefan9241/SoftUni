using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> stolenItems = new List<string>();
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Yohoho!")
            {
                if (commands[0] == "Loot")
                {


                    for (int i = 1; i < commands.Length; i++)
                    {
                        if (!treasure.Contains(commands[i]))
                        {
                            treasure.Insert(0, commands[i]);
                        }
                    }


                }
                else if (commands[0] == "Drop")
                {

                    int index = int.Parse(commands[1]);
                    if (index > treasure.Count - 1 || index < 0)
                    {
                        commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    string item = treasure[index];
                    treasure.RemoveAt(index);
                    treasure.Add(item);
                }
                else if (commands[0] == "Steal")
                {
                    int count = int.Parse(commands[1]);

                    if (count > treasure.Count - 1)
                    {
                        Console.WriteLine(string.Join(", ", treasure));
                        treasure.RemoveRange(0, treasure.Count);
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int indexToRemove = treasure.Count - 1;
                            string stolenItem = treasure[indexToRemove];
                            treasure.RemoveAt(indexToRemove);
                            stolenItems.Add(stolenItem);
                        }
                        stolenItems.Reverse();
                        Console.WriteLine(string.Join(", ", stolenItems));
                        stolenItems.Clear();
                    }
                }
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            double totalSum = 0;
            for (int i = 0; i < treasure.Count; i++)
            {
                double sum = treasure[i].Count();
                totalSum += sum;
            }
            double countTreasures = treasure.Count;
            totalSum = totalSum / countTreasures;

            if (treasure.Count <= 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {totalSum:f2} pirate credits.");
            }
        }
    }
}