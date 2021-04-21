using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string month =Console.ReadLine();
            double numNights = double.Parse(Console.ReadLine());
            double studioPerNight = 0;
            double appartmentPerNight = 0;
            double discountStudio = 0;
            double discountApartment = 0;
            switch (month)
            {
                case "May":
                case "October":
                    studioPerNight = 50;
                    if (numNights > 7 && numNights <= 14)
                    {
                        discountStudio = 0.5;
                    }
                    else if (numNights > 14)
                    {
                        discountStudio = 0.30;
                    }
                    appartmentPerNight = 65;
                    if (numNights > 14)
                    {
                        discountApartment = 0.10;
                    }
                    break;
                case "June":
                case "September":
                    studioPerNight = 75.20;
                    appartmentPerNight = 68.70;
                    if (numNights > 14)
                    {
                        discountStudio = 0.20;   
                        discountApartment = 0.10;
                    }
                    break;
                case "July":
                case "August":
                    studioPerNight = 76;
                    appartmentPerNight = 77;
                    if (numNights > 14)
                    {
                        discountApartment = 0.10;
                    }
                    break;
            }
            if (numNights > 14)
            {
                double price = numNights * appartmentPerNight;
                double totalPriceApartment = price - price * discountApartment;
                Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
            }
            else if(numNights <= 14)
            {
                double totalPriceApartment = numNights * appartmentPerNight;
                Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
            }

            double priceStudio = numNights * studioPerNight;
            double totalPriceStudio = priceStudio - priceStudio * discountStudio;
            Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
            
        }
    }
}
