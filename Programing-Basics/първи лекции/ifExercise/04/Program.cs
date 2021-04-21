using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "cm")
            {
                num = num / 100;
            }
            else if (inputUnit == "mm")
            {
                num /= 1000;
            }
            else if (inputUnit == "m")
            {
                num /= 1;
            }
            if (outputUnit == "cm")
            {
                num = num * 100;
            }
            else if (outputUnit == "mm")
            {
                num *= 1000;
            }
            else if (outputUnit == "m")
            {
                num *= 1;
            }
            Console.WriteLine($"{num:F3}");
        }
    }
}
