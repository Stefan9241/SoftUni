using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(i % 2 == 0)
                {
                    sumEven += number;
                }
                else
                {
                    sumOdd += number;
                }
            }
            if (sumOdd == sumEven)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+ sumOdd);
            }
            else
            {
                int diff = Math.Abs(sumEven - sumOdd);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
