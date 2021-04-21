using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double face = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;
            Console.WriteLine($"{face:f2}");
            Console.WriteLine($"{perimeter:f2}");

        }
    }
}
