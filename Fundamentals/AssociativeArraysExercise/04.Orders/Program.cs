using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> input = new Dictionary<string, List<double>>();
            string[] commands = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "buy")
            {
                string name = commands[0];
                double price = double.Parse(commands[1]);
                double quantity = double.Parse(commands[2]);
                if (input.ContainsKey(name) == false)
                {
                    input.Add(name, new List<double> { price,quantity});
                }
                else
                {
                    input[name][0] = price;
                    input[name][1] += quantity;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in input)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]}");
            }
        }
    }
}
