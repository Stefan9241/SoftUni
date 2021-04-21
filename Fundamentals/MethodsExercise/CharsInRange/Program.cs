using System;

namespace CharsInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());

            PrintBetween(input1, input2);
        }

        private static void PrintBetween(char start, char end)
        {
            if (start > end)
            {
                char first = start;
                start = end;
                end = first;
                
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
