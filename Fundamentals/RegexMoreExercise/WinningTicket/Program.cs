using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#$^]{1})\1{5,10}";
            Regex regex = new Regex(pattern);
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim();
                if (input[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string firstPart = input[i].Substring(0, input[i].Length / 2);
                string secondpart = input[i].Substring(input[i].Length / 2);
                Match firstPartCheck = regex.Match(firstPart);
                Match secondPartCheck = regex.Match(secondpart);
                if (firstPartCheck.Success && secondPartCheck.Success)
                {
                    int countFirst = firstPartCheck.Value.ToString().Length;
                    int countSecond = secondPartCheck.Value.ToString().Length;
                    if (countFirst < 10)
                    {
                        int lenght = countFirst > countSecond ? countSecond : countFirst;
                        char symbol = firstPartCheck.Value[0];
                        Console.WriteLine($"ticket \"{input[i]}\" - {lenght}{symbol}");
                    }
                    else if (countFirst == 10 && countSecond == 10)
                    {
                        char symbol = firstPartCheck.Value[0];
                        Console.WriteLine($"ticket \"{input[i]}\" - {firstPartCheck.Length}{symbol} Jackpot!");
                    }
                }
                else 
                {
                    Console.WriteLine($"ticket \"{input[i]}\" - no match");
                }
            }
        }
    }
}