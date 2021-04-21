using System;

namespace Резервоар_за_гориво
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            if(text != "Diesel" && text != "Gasoline" && text != "Gas")
            {
                Console.WriteLine("Invalid fuel!");
                Environment.Exit(0);
            }
            if (number >= 25)
            {
                Console.WriteLine($"You have enough {text.ToLower()}.");
            }
            else if (number < 25)
            {
                Console.WriteLine($"Fill your tank with {text.ToLower()}!");
            }
        }
    }
}
