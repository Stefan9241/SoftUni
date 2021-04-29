using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            int movesCounter = 0;
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "end")
            {
                movesCounter++;
                int firstInt = int.Parse(command[0]);
                int secondInt = int.Parse(command[1]);
                if (firstInt > input.Count - 1 || secondInt > input.Count - 1 || firstInt == secondInt ||
                    firstInt < 0 || secondInt < 0)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string additional = "-" + movesCounter + "a";
                    string additional2 = "-" + movesCounter + "a";

                    int insertInt = input.Count / 2;
                    input.Insert(insertInt, additional);
                    input.Insert(insertInt + 1, additional2);
                }
                else if (input[firstInt] == input[secondInt])
                {
                    string element = input[firstInt];
                    if (firstInt < secondInt)
                    {
                        input.RemoveAt(firstInt);
                        input.RemoveAt(secondInt - 1);
                    }
                    else
                    {
                        input.RemoveAt(firstInt);
                        input.RemoveAt(secondInt);
                    }

                    Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                }
                else if (input[firstInt] != input[secondInt])
                {
                    Console.WriteLine("Try again!");
                }


                if (input.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    return;
                }
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
