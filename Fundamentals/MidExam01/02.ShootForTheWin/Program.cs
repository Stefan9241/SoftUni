using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int shotTargets = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                int index = int.Parse(command);
                
                if (index < 0 || index > input.Length - 1 || input[index] == -1)
                {
                    command = Console.ReadLine();
                    continue;
                }
                int shootedNumber = input[index];
                shotTargets++;
                input[index] = -1;
                
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == -1)
                    {
                        continue;
                    }
                    else if (shootedNumber >= input[i])
                    {
                        input[i] += shootedNumber;
                    }
                    else if (shootedNumber < input[i])
                    {
                        input[i] -= shootedNumber;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', input)}");
        }
    }
}
