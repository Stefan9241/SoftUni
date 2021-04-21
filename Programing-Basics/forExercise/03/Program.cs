using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double evenMin = int.MaxValue;
            double evenMax = int.MinValue;
            double oddSum = 0;
            double oddMin = int.MaxValue;
            double oddMax = int.MinValue;
            for (int i = 1; i <= count; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += currentNumber;
                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }
                }
                else
                {
                    oddSum += currentNumber;
                    if (oddMax < currentNumber)
                    {
                        oddMax = currentNumber;
                    }
                    if (oddMin > currentNumber)
                    {
                        oddMin = currentNumber;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddSum == 0)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenSum == 0)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
