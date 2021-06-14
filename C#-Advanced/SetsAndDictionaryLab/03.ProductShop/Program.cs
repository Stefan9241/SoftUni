using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string,double>>();

            string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Revision")
            {
                string shopName = commands[0];
                string productName = commands[1];
                double priceOfProduct = double.Parse(commands[2]);

                if (shops.ContainsKey(shopName))
                {
                    shops[shopName].Add(productName, priceOfProduct);
                }
                else
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                    shops[shopName].Add(productName, priceOfProduct);
                }

                commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
