using System;

namespace __Рибна_борса
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerelPriceKG = double.Parse(Console.ReadLine());
            double toyPriceKG = double.Parse(Console.ReadLine());
            double bonitoKG = double.Parse(Console.ReadLine());
            double horseMacherelKG = double.Parse(Console.ReadLine());
            double musselsPriceKG = double.Parse(Console.ReadLine());
            double priceBonito = mackerelPriceKG + mackerelPriceKG * 0.60;
            double bonitoSum = priceBonito * bonitoKG;
            double priceHorsMache = toyPriceKG + toyPriceKG * 0.80;
            double horseMacheSum = priceHorsMache * horseMacherelKG;
            double musselsSum = musselsPriceKG * 7.50;
            double totalSum = musselsSum + horseMacheSum + bonitoSum;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
