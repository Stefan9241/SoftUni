using System;

namespace __Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Printing_Triangle(number);
        }

        private static void Printing_Triangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int row = 1; row <= i; row++)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine();
            }

            for (int i = number; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
