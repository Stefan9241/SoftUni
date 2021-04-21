using System;

namespace Сума_от_две_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            int rightCounter = 0;
            for (int num =start ; num <= end; num++)
            {
                for (int num2 = start ; num2 <=end; num2++)
                {
                    counter++;
                    if (num + num2 == magic)
                    {
                        rightCounter = counter;
                        Console.WriteLine($"Combination N:{rightCounter} ({num} + {num2} = {magic})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magic}");
        }
    }
}
