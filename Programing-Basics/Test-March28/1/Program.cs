using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBitcoin = int.Parse(Console.ReadLine());
            double numUana = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double bitcoinPrice = numBitcoin * 1168;
            double priceUana = numUana * 0.15;
            double priceDolars = priceUana * 1.76;
            double euroPrice = (bitcoinPrice + priceDolars) / 1.95;
            double result = euroPrice - euroPrice * (commision*0.01);

            Console.WriteLine($"{result:f2}");

        }
    }
}
