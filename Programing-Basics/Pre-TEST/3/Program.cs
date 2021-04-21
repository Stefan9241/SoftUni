using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numHours = int.Parse(Console.ReadLine());
            int numPeople = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double priceForHour = 0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    switch (dayOrNight)
                    {
                        case "day":
                            priceForHour = 10.50;
                            break;
                        case "night":
                            priceForHour = 8.40;
                            break;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    switch (dayOrNight)
                    {
                        case "day":
                            priceForHour = 12.60;
                            break;
                        case "night":
                            priceForHour = 10.20;
                            break;
                    }
                    break;
            }
            if (numPeople >= 4)
            {
                priceForHour -= priceForHour * 0.10;
            }
            if (numHours >= 5)
            {
                priceForHour /= 2;
            }
            Console.WriteLine($"Price per person for one hour: {priceForHour:f2}");
            Console.WriteLine($"Total cost of the visit: {priceForHour * numPeople * numHours:f2}");
        }
    }
}
