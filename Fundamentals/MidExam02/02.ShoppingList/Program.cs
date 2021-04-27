using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commandArgs[0] != "Go")
            {
                
                string item = commandArgs[1];
                string command = commandArgs[0];
                bool isExist = IsExisting(item, groceries);
                if (command == "Urgent")
                {

                    if (!isExist)
                    {
                        groceries.Insert(0, item);
                    }

                }
                else if (command == "Unnecessary")
                {
                    if (isExist)
                    {
                        groceries.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string newItem = commandArgs[2];
                    if (isExist)
                    {
                        int index = groceries.IndexOf(item);
                        groceries[index] = newItem;
                    }
                }
                else if (command == "Rearrange")
                {
                    if (isExist)
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                }
                commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ",groceries));
        }
        static bool IsExisting(string item, List<string> grocery)
        {
            for (int i = 0; i < grocery.Count; i++)
            {
                if (grocery[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
