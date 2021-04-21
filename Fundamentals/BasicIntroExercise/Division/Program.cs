using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string divison = "";
            if (number % 10 == 0)
            {
                divison = "10";
            }
            else if (number % 7 == 0)
            {
                divison = "7";
            }
            else if (number % 6 == 0)
            {
                divison = "6";
            }
            else if (number % 3 == 0)
            {
                divison = "3";
            }
            else if (number % 2 == 0)
            {
                divison = "2";
            }
            else
            {
                Console.WriteLine("Not divisible");
                return;
            }
            Console.WriteLine($"The number is divisible by {divison}");
        }
    }
}
