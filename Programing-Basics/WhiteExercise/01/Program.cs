using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string neededBook = Console.ReadLine();
            string book = Console.ReadLine();
            int counter = 0;
            while (book != "No More Books")
            {
                if (book == neededBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    Environment.Exit(0);
                }
                counter++;
                book = Console.ReadLine();
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {counter} books.");
        }
    }
}
