using System;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!([A-Z][a-z]+)!:\[([a-zA-Z]{8,})\]";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Match match = Regex.Match(text, pattern);
                if (match.Success)
                {
                    string command = match.Groups[1].Value;
                    string secredMsg = match.Groups[2].Value;
                    int[] arrayOfAsciNums = new int[secredMsg.Length];
                    for (int j = 0; j < secredMsg.Length; j++)
                    {
                        arrayOfAsciNums[j] = secredMsg[j];
                    }

                    Console.WriteLine($"{command}: {string.Join(" ",arrayOfAsciNums)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }

            }
        }
    }
}
