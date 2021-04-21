using System;

namespace __Зеленчукова_борса
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegPriceForOneKilo = double.Parse(Console.ReadLine());
            double fruitPriceForOneKilo = double.Parse(Console.ReadLine());
            double vegKG = double.Parse(Console.ReadLine());
            double fruitKG = double.Parse(Console.ReadLine());

            double priceVegEU = vegKG * vegPriceForOneKilo;
            double pricefruitEU = fruitPriceForOneKilo * fruitKG;

            double totalPrice = (pricefruitEU + priceVegEU) / 1.94;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
