using System;

namespace Yoda
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double priceLighsabre = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());
            int freeBelts = countStudents / 6;
            double sabres = (Math.Ceiling(countStudents * 1.10));
            double totalPrice = (priceLighsabre * sabres) + ((priceBelt * (countStudents- freeBelts)) + priceRobe * countStudents);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - budget:F2}lv more.");
            }

        }
    }
}
