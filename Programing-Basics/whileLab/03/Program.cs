using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (num >= sum)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                if (sum >= num)
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }
    }
}
