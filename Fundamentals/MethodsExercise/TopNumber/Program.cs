using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            


            for (int i = 1; i <= number; i++)
            {
                bool divisibleByEight = isDevisible(i);
                string input = i.ToString();
                bool hasOddDigit = oddDigitCheck(input);
                if (divisibleByEight && hasOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool oddDigitCheck(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int curr = input[i];
                if (curr % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isDevisible(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                int nextNum = num % 10;
                sum += nextNum;
                num -= nextNum;
                num /= 10;

            }
            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
