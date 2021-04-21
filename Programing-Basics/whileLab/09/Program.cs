using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int filledSpace = 0;
            int freeSpace = width * length * height;
            string input = Console.ReadLine();
            while (freeSpace > filledSpace && input != "Done")
            {
                int boxes = int.Parse(input);
                filledSpace += boxes;
                if (filledSpace >= freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {filledSpace - freeSpace} Cubic meters more.");
                    Environment.Exit(0);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{freeSpace - filledSpace} Cubic meters left.");
        }
    }
}
