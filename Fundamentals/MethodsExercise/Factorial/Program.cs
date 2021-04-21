using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double num1Factorial = GetFactorial(num1);
            double num2Factorial = GetFactorial(num2);
            double result = num1Factorial / num2Factorial;
            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
