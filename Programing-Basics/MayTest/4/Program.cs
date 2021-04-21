using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            // На първи ред – бюджетът - реално число в интервала[1.00… 100000.00]
            //След това поредица от два реда(до получаване на команда "Stop" или при заявка за купуване на продукт, чиято стойност е по-висока от наличния бюджет) :
            //Име на продукта – текст
            //Цена на продукта – реално число в интервала[1.00… 5000.00]
            double budget = double.Parse(Console.ReadLine());
            int countProduts = 0;
            string product = Console.ReadLine();
            double price = 0;
            while (product != "Stop")
            {
                countProduts++;
                double priceOfProduct = double.Parse(Console.ReadLine());
                if (countProduts % 3 == 0)
                {
                    price += priceOfProduct / 2;
                }
                else
                {
                    price += priceOfProduct;
                }
                if (price > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {Math.Abs(price - budget):F2} leva!");
                    Environment.Exit(0);
                }
                
                product = Console.ReadLine();
            }
            Console.WriteLine($"You bought {countProduts} products for {price:F2} leva.");
        }
    }
}
