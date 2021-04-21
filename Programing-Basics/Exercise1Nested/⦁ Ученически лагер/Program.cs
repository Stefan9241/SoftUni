using System;

namespace __Ученически_лагер
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string type = Console.ReadLine();
            int numStudents = int.Parse(Console.ReadLine());
            int numNights = int.Parse(Console.ReadLine());
            double priceNight = 0;
            string sport = "";
            switch (season)
            {
                case "Winter":
                    switch (type)
                    {
                        case "boys":
                            priceNight = 9.60;
                            sport = "Judo";
                            break;
                        case "girls":
                            priceNight = 9.60;
                            sport = "Gymnastics";
                            break;
                        case "mixed":
                            priceNight = 10;
                            sport = "Ski";
                            break;
                    }
                    break;
                case "Spring":
                    switch (type)
                    {
                        case "boys":
                            priceNight = 7.20;
                            sport = "Tennis";
                            break;
                        case "girls":
                            priceNight = 7.20;
                            sport = "Athletics";
                            break;
                        case "mixed":
                            priceNight = 9.50;
                            sport = "Cycling";
                            break;
                    }
                    break;
                case "Summer":
                    switch (type)
                    {
                        case "boys":
                            priceNight = 15;
                            sport = "Football";
                            break;
                        case "girls":
                            priceNight = 15;
                            sport = "Volleyball";
                            break;
                        case "mixed":
                            priceNight = 20;
                            sport = "Swimming";
                            break;
                    }
                    break;
            }
            double totalPrice = numNights * (numStudents * priceNight);
            if (numStudents >= 50)
            {
                totalPrice -= totalPrice * 0.50;
            }
            else if (numStudents >= 20 && numStudents < 50)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (numStudents >= 10 && numStudents < 20)
            {
                totalPrice -= totalPrice * 0.05;
            }
            Console.WriteLine($"{sport} {totalPrice:f2} lv.");

        }
    }
}
