using System;

namespace RefSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isSpecial = false;
            for (int index = 1; index <= number; index++)
            {
                int sum = 0;
                int currentDigit = index;
                while (index > 0)
                {
                    sum += index % 10;
                    index = index / 10;
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currentDigit, isSpecial);
                
                index = currentDigit;
            }

        }
    }
}
