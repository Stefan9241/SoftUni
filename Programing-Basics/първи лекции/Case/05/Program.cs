using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = (Console.ReadLine());
            string city = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            double priceForProduct = 0;
            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    priceForProduct = 0.50;
                }
                else if (city == "Plovdiv")
                {
                    priceForProduct = 0.40;
                }
                else
                {
                    priceForProduct = 0.45;
                } 
            }
            else if ( product == "water")
            {
                if (city == "Sofia")
                {
                    priceForProduct = 0.80;
                }
                else if (city == "Plovdiv")
                {
                    priceForProduct = 0.70;
                }
                else
                {
                    priceForProduct = 0.70;
                }
            }
            else if (product == "beer")
            {
                if (city == "Sofia")
                {
                    priceForProduct = 1.20;
                }
                else if (city == "Plovdiv")
                {
                    priceForProduct = 1.15;
                }
                else
                {
                    priceForProduct = 1.10;
                }
            }
            else if(product == "sweets")
            {
                if (city == "Sofia")
                {
                    priceForProduct = 1.45;
                }
                else if (city == "Plovdiv")
                {
                    priceForProduct = 1.30;
                }
                else
                {
                    priceForProduct = 1.35;
                }
            }
            else if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    priceForProduct = 1.60;
                }
                else if (city == "Plovdiv")
                {
                    priceForProduct = 1.50;
                }
                else
                {
                    priceForProduct = 1.55;
                }
            }
            Console.WriteLine(priceForProduct * number);
        }
    }
}
