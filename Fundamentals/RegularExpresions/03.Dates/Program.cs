using System;
using System.Text.RegularExpressions;

namespace _04._MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([-./])(?<month>[A-Z][a-z]{2})(\1)(?<year>\d{4})\b";
            string datesInput = Console.ReadLine();

            var matches = Regex.Matches(datesInput, pattern);

            foreach (Match dates in matches)
            {
                Console.WriteLine("Day: {0}, Month: {1}, Year: {2}",
                    dates.Groups["day"],
                    dates.Groups["month"],
                    dates.Groups["year"]
                    );
            }
            Console.WriteLine();
        }
    }
}