using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double counter1 = 0;
            double counter2 = 0;
            double counter3 = 0;
            for (int i = 0; i < number; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());
                if (currentNumber % 2 == 0)
                {
                    counter1++;
                }
                if (currentNumber % 3 == 0)
                {
                    counter2++;
                }
                if (currentNumber % 4 == 0)
                {
                    counter3++;
                }
            }
            double p1 = counter1 / number * 100;
            double p2 = counter2 / number * 100;
            double p3 = counter3 / number * 100;


            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
