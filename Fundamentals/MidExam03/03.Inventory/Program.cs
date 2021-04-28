using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Craft!")
            {
                string item = commands[1];
                if (commands[0] == "Collect")
                {
                    if (!input.Contains(item))
                    {
                        input.Add(item);
                    }
                }
                else if (commands[0] == "Drop")
                {
                    if (input.Contains(item))
                    {
                        input.Remove(item);
                    }
                }
                else if (commands[0] == "Renew")
                {
                    if (input.Contains(item))
                    {
                        string itemToPutLast = item;
                        input.Remove(item);
                        input.Add(itemToPutLast);
                    }
                }
                else if (commands[0] == "Combine Items")
                {
                    string[] oldAndNewItem = commands[1].Split(":");
                    string oldItem = oldAndNewItem[0];
                    string newItem = oldAndNewItem[1];
                    if (input.Contains(oldItem))
                    {
                        int indexOfOld = input.IndexOf(oldItem);
                        input.Insert(indexOfOld + 1, newItem);
                    }

                }

                commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(", ",input));
        }
    }
}
