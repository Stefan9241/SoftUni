using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lengh = int.Parse(Console.ReadLine());
            double totalSize = width * lengh;
            double cakeTaken = 0;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                double pieceOfCake = double.Parse(input);
                cakeTaken += pieceOfCake;
                if (cakeTaken >= totalSize)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (totalSize > cakeTaken)
            {
                Console.WriteLine($"{totalSize - cakeTaken} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeTaken - totalSize)} pieces more.");
            }

        }
    }
}
