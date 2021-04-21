using System;

namespace Магазин_за_цветя
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnol = int.Parse(Console.ReadLine());
            int ziumbu = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double priceForGift = double.Parse(Console.ReadLine());

            double totalSum = magnol * 3.25 + ziumbu * 4 + rose * 3.50 + cactus * 8;
            totalSum -= totalSum * 0.05;

            if (totalSum >= priceForGift)
            {
                Console.WriteLine($"She is left with {Math.Floor(totalSum - priceForGift)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(priceForGift - totalSum)} leva.");
            }

        }
    }
}
