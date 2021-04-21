using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string inputPassword =Console.ReadLine();
            while (inputPassword != password)
            {
                inputPassword =Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
