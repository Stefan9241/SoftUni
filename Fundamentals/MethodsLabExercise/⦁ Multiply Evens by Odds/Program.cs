using System;

namespace __Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
           
            int sumEven = GetSumOfEvenNum(num);
            int sumOdd = GetSumOfOddNum(num);
            int result = sumEven * sumOdd;
            Console.WriteLine(result);
        }

        private static int GetSumOfOddNum(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 1)
                {
                    sum += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }
            return sum;
        }

        private static int GetSumOfEvenNum(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 0)
                {
                    sum += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }
            return sum;
        }
    }
}
