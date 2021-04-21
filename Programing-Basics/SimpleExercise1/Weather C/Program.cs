using System;

namespace Weather_C
{
    class Program
    {
        static void Main(string[] args)
        {
            double c = double.Parse(Console.ReadLine());
            if (c >= 26 && c <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if (c >=20.1 && c <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (c >= 15 && c <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (c >= 12 && c <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (c >= 5 && c <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
