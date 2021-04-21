using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if (text == "add")
            {
                Add(number, number2);
            }
            else if (text == "divide")
            {
                Divide(number, number2);
            }
            else if (text == "multiply")
            {
                Multiply(number, number2);
            }
            else if (text == "subtract")
            {
                Subtract(number, number2);
            }

        }

        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
        static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

    }
}
