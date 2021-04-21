using System;

namespace Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            char a = char.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double result = 0;
            switch (a)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
            }
            Console.WriteLine(Math.Round(result, 2));
        }

    }
}
