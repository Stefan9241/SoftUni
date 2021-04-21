using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 == 0)
            {
                PrintChars(input);
            }
            else
            {
                PrintOneChar(input);
            }
        }

        private static void PrintOneChar(string input)
        {
            int digit = input.Length / 2;
            string chars = input.Substring(digit, 1);
            Console.WriteLine(chars);
        }

        private static void PrintChars(string input)
        {
            int startDigit = input.Length / 2 - 1;
            string chars = input.Substring(startDigit, 2);
            Console.WriteLine(chars);
        }
    }
}
