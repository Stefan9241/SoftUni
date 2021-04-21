using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int factNumber = number;
            int factSum = 0;
            int currenNumber = 0;

            while (factNumber != 0)
            {
                currenNumber = number % 10;
                factNumber /= 10;

                int factorial = 1;
                for (int i = 1; i <= currenNumber; i++)
                {
                    factorial *= i;
                }
                factSum += factorial;
            }
            string result = "";
            if (number == factSum)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
