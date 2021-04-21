using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>(numberCommands);
            for (int i = 0; i < numberCommands; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                if (command.Length <= 3)
                {
                    if (!guests.Contains(command[0]))
                    {
                        guests.Add(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(command[0]))
                    {
                        guests.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }

            }
            Console.WriteLine(string.Join(Environment.NewLine,guests));
        }
    }
}
