using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int kids = 0;
            int adults = 0;
            while (command != "Christmas")
            {
                int number = int.Parse(command);
                if (number <= 16)
                {
                    kids++;
                }
                else
                {
                    adults++;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {kids * 5}");
            Console.WriteLine($"Money for sweaters: {adults * 15}");
        }
    }
}
