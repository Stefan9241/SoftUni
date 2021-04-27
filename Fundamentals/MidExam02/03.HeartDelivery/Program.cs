using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int index = 0;
            string[] cmdArgs = Console.ReadLine().Split(); // commands
            while (cmdArgs[0] != "Love!")
            {
                int lenght = int.Parse(cmdArgs[1]);  // jump lenght
                if (index + lenght > input.Length - 1) //if lenght is too big == 0
                {
                    index = 0;
                }
                else
                {
                    index += lenght;
                }

                if (input[index] == 0)  
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }
                else
                {
                    input[index] -= 2;
                    if (input[index] < 1)
                    {
                        input[index] = 0;
                        Console.WriteLine($"Place {index} has Valentine's day.");
                    }

                }

                cmdArgs = Console.ReadLine().Split();
            }
            bool isSuccesful = true;
            int countFails = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != 0)
                {
                    countFails++;
                    isSuccesful = false;
                }
                               
            }
            Console.WriteLine($"Cupid's last position was {index}.");
            if (isSuccesful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {countFails} places.");
            }
        }
    }
}
