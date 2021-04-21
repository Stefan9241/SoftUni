using System;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruit = Console.ReadLine();
            var day = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());

            double priceForFruit = 0;

            if (fruit == "banana")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 2.50;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 2.70;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "apple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 1.20;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 1.25;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "orange")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 0.85;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 0.90;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "grapefruit")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 1.45;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 1.60;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "kiwi")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 2.70;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 3.00;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "apple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 1.20;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 1.25;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "pineapple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 5.50;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 5.60;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (fruit == "grapes")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        priceForFruit = 3.85;
                        break;
                    case "Saturday":
                    case "Sunday":
                        priceForFruit = 4.20;
                        break;
                }
                double totalPrice = priceForFruit * number;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
