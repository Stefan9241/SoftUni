using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            PrintOrder(text, number);
        }

        private static void PrintOrder(string text, int number)
        {
            double price = 0;
            switch (text)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }
            double result = price * number;
            Console.WriteLine($"{result:F2}");
        }
    }
}
