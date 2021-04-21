using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int asciSum = 0;
            for (int i = 0; i < n; i++)
            {
                char c = char.Parse(Console.ReadLine());
                asciSum += c;
            }
            Console.WriteLine($"The sum equals: {asciSum}");
        }
    }
}
