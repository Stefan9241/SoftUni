using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            int maxSum = 0;
            int minSum = 0;
            for (int i = 0; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                maxSum += num;
                minSum += num;
                if (min > num)
                {
                    min = num;
                }
                if (max < num)
                {
                    max = num;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
