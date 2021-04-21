using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            int[] specialBombNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = specialBombNumbers[0];
            int power = specialBombNumbers[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber == bombNumber)
                {
                    int startIndex = i - power;
                    if (startIndex <0)
                    {
                        startIndex = 0;
                    }
                    int endIndex = i + power;
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }
                    int countToRemove = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, countToRemove);
                    i = startIndex - 1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
