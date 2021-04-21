using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            for (int i = 0; i < number; i++)
            {
                double current = double.Parse(Console.ReadLine());
                if (current % 2 == 0)
                {
                    p1++;
                }
                if (current % 3 == 0)
                {
                    p2++;
                }
                if (current % 4 == 0)
                {
                    p3++;
                }
            }
            Console.WriteLine($"{p1 / number * 100:f2}%");
            Console.WriteLine($"{p2 / number * 100:f2}%");
            Console.WriteLine($"{p3 / number * 100:f2}%");
        }
    }
}
