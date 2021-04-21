using System;

namespace SumOfOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;
            for (int i = 1; i <= 1000; i+=2)
            {
                    sum += i;
                    Console.WriteLine(i);
                counter++;
                if (counter == number)
                {
                    break;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
