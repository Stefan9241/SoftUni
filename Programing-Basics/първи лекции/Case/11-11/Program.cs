using System;

namespace _11_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string dayOfWeek = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0d;

            if (dayOfWeek == "monday" || dayOfWeek == "tuesday" || dayOfWeek == "wednesday" || dayOfWeek == "thursday" || dayOfWeek == "friday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.5;
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.2;
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 2.7;
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.5;
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 3.85;
                }
            }
            else if (dayOfWeek == "saturday" || dayOfWeek == "sunday")
            {
                if (fruit == "banana")
                {
                    price = quantity * 2.7;
                }
                else if (fruit == "apple")
                {
                    price = quantity * 1.25;
                }
                else if (fruit == "orange")
                {
                    price = quantity * 0.9;
                }
                else if (fruit == "grapefruit")
                {
                    price = quantity * 1.6;
                }
                else if (fruit == "kiwi")
                {
                    price = quantity * 3;
                }
                else if (fruit == "pineapple")
                {
                    price = quantity * 5.6;
                }
                else if (fruit == "grapes")
                {
                    price = quantity * 4.2;
                }
            }

            if (price <= 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
