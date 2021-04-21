using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (
                int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());
                sum += current;
                if (current > max)
                {
                    max = current;
                }
            }
            int sumWithOutMax = sum - max;
            if (sumWithOutMax == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs(max - sumWithOutMax);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
