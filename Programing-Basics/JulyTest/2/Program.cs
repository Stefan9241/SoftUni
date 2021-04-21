using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMoreThen20Kg = double.Parse(Console.ReadLine());
            double kgLuggedge = double.Parse(Console.ReadLine());
            double daysTravel = double.Parse(Console.ReadLine());
            double numLuggedge = double.Parse(Console.ReadLine());
            double priceOneLuggedge = 0;

            if (kgLuggedge <= 10)
            {
                priceOneLuggedge = priceMoreThen20Kg * 0.20;
            }
            else if (kgLuggedge > 10 && kgLuggedge <= 20)
            {
                priceOneLuggedge = priceMoreThen20Kg * 0.50;
            }
            else if (kgLuggedge > 20)
            {
                priceOneLuggedge = priceMoreThen20Kg;
            }
            if (daysTravel > 30)
            {
                priceOneLuggedge += priceOneLuggedge * 0.10;
            }
            else if (daysTravel >= 7 && daysTravel <= 30)
            {
                priceOneLuggedge += priceOneLuggedge * 0.15;
            }
            else
            {
                priceOneLuggedge += priceOneLuggedge * 0.40;
            }
            Console.WriteLine($"The total price of bags is: {priceOneLuggedge * numLuggedge:F2} lv. ");
        }
    }
}
