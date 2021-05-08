using System;

namespace _02.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;

            foreach (var item in input)
            {
                int lenght = item.Length;
                for (int i = 0; i < lenght; i++)
                {
                    result += item;
                }
            }
            Console.WriteLine(result);
        }
    }
}
