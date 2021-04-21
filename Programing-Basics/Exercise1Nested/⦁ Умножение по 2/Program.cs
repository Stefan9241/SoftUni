using System;

namespace __Умножение_по_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            while (num >= 0)
            {
                Console.WriteLine($"Result: {num * 2:F2}");
                num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Negative number!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
