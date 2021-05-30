using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(=|\/)[A-Z][A-Za-z]{2,}\1"; ;
            Regex validator = new Regex(pattern);
            MatchCollection match = validator.Matches(input);
            int travelPoints = 0;
            List<string> destinations = new List<string>();
            for (int i = 0; i < match.Count; i++)
            {
                string currentMatch = match[i].ToString();
                travelPoints += currentMatch.Length - 2;
                string destination = currentMatch.Substring(1, (currentMatch.Length - 1) - 1);
                destinations.Add(destination);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
