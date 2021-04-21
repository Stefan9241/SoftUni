using System;

namespace __Rent_a_car
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0;
            string type = "";
            string clas = "";

            if (budget <= 100)
            {
                clas = "Economy class";
                if (season == "Summer")
                {
                    type = "Cabrio";
                    sum = budget - budget * 0.35;

                }
                else if (season == "Winter")
                {
                    type = "Jeep";
                    sum = budget - budget * 0.65;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                clas = "Compact class";
                if (season == "Summer")
                {
                    type = "Cabrio";
                    sum = budget - budget * 0.45;

                }
                else if (season == "Winter")
                {
                    type = "Jeep";
                    sum = budget - budget * 0.80;
                }
            }
            else if (budget > 500)
            {
                clas = "Luxury class";
                type = "Jeep";
                sum = budget - budget * 0.90;
            }
            Console.WriteLine($"{clas}");
            Console.WriteLine($"{type} - {budget - sum:F2}");
        }
    }
}
