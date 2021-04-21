using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            
            for (int i = num1; i <= num2; i++)
            {
                string currentNumber = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    int digit = int.Parse(currentNumber[j].ToString());
                    
                    if (j % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }

                }
                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            }
            
        }
    }
}
