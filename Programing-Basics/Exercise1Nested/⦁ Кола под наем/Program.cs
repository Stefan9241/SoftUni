using System;

namespace __Кола_под_наем
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0;
            string settlement = "";
            string location = "";
            if (budget <= 1000)
            {
                settlement = "Camp";

                if (season == "Summer")
                {
                    location = "Alaska";
                    sum = budget - budget * 0.65;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    sum = budget - budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                settlement = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    sum = budget - budget * 0.80;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    sum = budget - budget * 0.60;
                }
            }
            else if (budget > 3000)
            {
                settlement = "Hotel";
                if (season == "Summer")
                {
                    location = "Alaska";
                    sum = budget - budget * 0.90;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    sum = budget - budget * 0.90;
                }
            }
            Console.WriteLine($"{location} - {settlement} - {budget - sum:F2}");
        }
    }
}
