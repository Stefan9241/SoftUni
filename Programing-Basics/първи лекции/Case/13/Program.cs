﻿using System;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();

            double pricePerNight = 0;
            double discount = 0;

            switch (room)
            {
                case "room for one person":
                    pricePerNight = 18;
                    break;
                case "apartment":
                    pricePerNight = 25;
                    if (days < 10)
                    {
                        discount = 0.30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.35;
                    }
                    else if (days > 15)
                    {
                        discount = 0.50;
                    }
                    break;
                case "president apartment":
                    pricePerNight = 35;
                    if (days < 10)
                    {
                        discount = 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.15;
                    }
                    else if (days > 15)
                    {
                        discount = 0.20;
                    }
                    break;
            }

            double totalPrice = (days - 1) * pricePerNight;
            totalPrice -= totalPrice * discount;

            if (feedback == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
