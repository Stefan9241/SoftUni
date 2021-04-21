using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            //чете цели числа докато не получи stop
            //търси сумата на всички прости и не прости
            //ако е отрицателно , number si negative 
            string input = Console.ReadLine();
            double sumPrime = 0;
            double sumNonPrime = 0;
            
            while (input != "stop")
            {
                double currentNumber = double.Parse(input);
                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    
                }
                else if (currentNumber <= 1)
                {
                    sumNonPrime += currentNumber;
                }
                else if (currentNumber == 2)
                {
                    sumPrime += currentNumber;
                }
                else if (currentNumber % 2 == 0)
                {
                    sumNonPrime += currentNumber;
                }
                else
                {
                    int boundary = (int)Math.Floor(Math.Sqrt(currentNumber));
                    bool prime = true;
                    for (int i = 3; i <= boundary; i += 2)
                    {
                        if (currentNumber % i == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime)
                    {
                        sumPrime += currentNumber;
                    }
                    else
                    {
                        sumNonPrime += currentNumber;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
