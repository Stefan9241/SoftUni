using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double totalPrice = 0;
            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;

                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;

                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                            if (group >= 10 && group <= 20)
                            {
                                totalPrice -= totalPrice * 0.05;
                            }
                    }
                    break;
            }
            if (group >= 100 && type == "Business")
            {
                group -= 10;
            }
            totalPrice = price * group;
            if (group >= 30 && type == "Students")
            {
                totalPrice = totalPrice * 0.85;
            }
            else if (group >= 10 && group <= 20 && type == "Regular")
            {
                totalPrice -= totalPrice * 0.95;
            }


            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
