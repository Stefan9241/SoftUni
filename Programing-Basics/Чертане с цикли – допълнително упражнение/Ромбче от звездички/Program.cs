using System;

namespace Ромбче_от_звездички
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int spaces = num - 1;
            int stars = 1;

            for (int row = 0; row < num; row++)
            {
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int i = 0; i < stars - 1; i++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
                stars++;
                spaces--;
            }
            stars = num - 1;
            spaces = 1;
            for (int row = 0; row < num - 1; row++)
            {
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int i = 0; i < stars - 1; i++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
                stars--;
                spaces++;
            }
        }
    }
}
