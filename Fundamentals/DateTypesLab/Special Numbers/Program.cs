using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int sumDigits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumDigits += digits % 10;
                    digits /= 10;
                }
                bool isSpecial = sumDigits == 5 || sumDigits == 7 || sumDigits == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
