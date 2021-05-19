using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBar
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|%$.]*<(\w+)>[^|%$.]*\|(\d+)\|[^|%$.]*?(\d+\.?\d*)\$";
            Regex regex = new Regex(pattern);

            string cmdArg = Console.ReadLine();
            double totalSum = 0;
            while (cmdArg != "end of shift")
            {
                Match match = regex.Match(cmdArg);
                if (match.Success)
                {
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double sum = price * count;
                    Console.WriteLine($"{customer}: {product} - {sum:f2}");
                    totalSum += sum;
                }

                cmdArg = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
