using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(", ");
            foreach (var name in input)
            {
                names.Add(name, 0);
            }

            string pattern = @"[\W\d]";
            string newPattern = @"[\WA-ZA-z]";

            string command = Console.ReadLine();
            while (command != "end of race")
            {
                string curName = Regex.Replace(command, pattern, "");
                string numbers = Regex.Replace(command, newPattern, "");
                int disctance = 0;
                foreach (var digit in numbers)
                {
                    int currentDigit = int.Parse(digit.ToString());
                    disctance += currentDigit;
                }
                if (names.ContainsKey(curName))
                {
                    names[curName] += disctance;
                }
                command = Console.ReadLine();
            }
            int count = 1;
            foreach (var name in names.OrderByDescending(x => x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {name.Key}");
                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
