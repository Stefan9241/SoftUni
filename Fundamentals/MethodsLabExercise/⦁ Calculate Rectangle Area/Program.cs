using System;

namespace __Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double result = Print(num1, num2);
            Console.WriteLine(result);
        }

        static double Print(double num1, double num2)
        {
            return (num1 * num2);
        }
    }
}
