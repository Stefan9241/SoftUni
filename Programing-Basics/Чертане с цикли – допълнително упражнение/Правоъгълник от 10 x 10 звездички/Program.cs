using System;

namespace Правоъгълник_от_10_x_10_звездички
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write("*", number);
                }
                Console.WriteLine();
            }
        }
    }
}
