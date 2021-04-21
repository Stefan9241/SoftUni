using System;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPen = int.Parse(Console.ReadLine());
            int numMarkers = int.Parse(Console.ReadLine());
            double prepForClean = double.Parse(Console.ReadLine());
            int numDiscount = int.Parse(Console.ReadLine());

            double penPrice = numPen * 5.80;
            double markerPrice = numMarkers * 7.20;
            double prepPrice = prepForClean * 1.20;
            double total = penPrice + markerPrice + prepPrice;
            double discount = numDiscount * 0.01;
            double result = total - total * discount;
            Console.WriteLine($"{result:F3}");

        }
    }
}
