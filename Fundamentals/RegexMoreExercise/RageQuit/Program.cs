using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([\D]+)([0-9]+)";

            MatchCollection matches = Regex.Matches(input, pattern);

            StringBuilder message = new StringBuilder();

            int symbolsCount = 0;

            foreach (Match item in matches)
            {
                string letters = item.Groups[1].Value;
                int number = int.Parse(item.Groups[2].Value);

                for (int i = 0; i < number; i++)
                {
                    message.Append(letters);
                }
            }

            string gibberish = message.ToString().ToUpper();
            symbolsCount = gibberish.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {symbolsCount}");
            Console.WriteLine(gibberish);
        }
    }
}
