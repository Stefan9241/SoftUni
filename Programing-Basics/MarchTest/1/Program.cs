using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int taxForAYear = int.Parse(Console.ReadLine());

            double sneakers = taxForAYear - taxForAYear * 0.40;
            double outfit = sneakers - sneakers * 0.20;
            double ball = outfit / 4;
            double accessories = ball / 5;
            double total = taxForAYear + sneakers + outfit + ball + accessories;
            Console.WriteLine($"{total:f2}");

        }
    }
}
