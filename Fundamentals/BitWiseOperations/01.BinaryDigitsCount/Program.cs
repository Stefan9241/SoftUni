using System;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryDigit = int.Parse(Console.ReadLine());
            int count = 0;

            while (number != 0)
            {
                int bitReminder = number % 2;      // return only 1 or 0
                if (bitReminder == binaryDigit)
                {
                    count++;
                }
                number = number / 2;              // we divide by 2, because binary system base 2
            }
            Console.WriteLine(count);
        }
    }
}
