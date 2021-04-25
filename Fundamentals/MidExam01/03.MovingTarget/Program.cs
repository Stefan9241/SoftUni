using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                string cmd = command[0];
                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);
                

                if (cmd == "Shoot")
                {
                    if (index < 0 || index > input.Count() - 1)
                    {
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    input[index] -= value;
                    if (input[index] <= 0)
                    {
                        input.RemoveAt(index);
                    }
                }
                else if (cmd == "Add")
                {
                    if (index < 0 || index > input.Count() - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        input.Insert(index, value);
                    }
                }
                else if(cmd == "Strike")
                {
                    if (index < 0 || index > input.Count() - 1 || index- value < 0 || index + value > input.Count() - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        input.RemoveRange(index-1, (value * 2) + 1);
                    }
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join('|',input));
        }
    }
}
