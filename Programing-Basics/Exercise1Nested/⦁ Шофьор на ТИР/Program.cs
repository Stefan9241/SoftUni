using System;

namespace __Шофьор_на_ТИР
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double km = double.Parse(Console.ReadLine());
            double priceForKm = 0;

            if (km <= 5000)
            {
                switch (season)
                {
                    case "Autumn":
                    case "Spring":
                        priceForKm = 0.75;
                        break;
                    case "Summer":
                        priceForKm = 0.90;
                        break;
                    case "Winter":
                        priceForKm = 1.05;
                        break;
                }
            }
            else if (km > 5000 && km <= 10000)
            {
                switch (season)
                {
                    case "Autumn":
                    case "Spring":
                        priceForKm = 0.95;
                        break;
                    case "Summer":
                        priceForKm = 1.10;
                        break;
                    case "Winter":
                        priceForKm = 1.25;
                        break;
                }
            }
            else if (km > 10000 && km <= 20000)
            {
                switch (season)
                {
                    case "Autumn":
                    case "Spring":
                    case "Summer":
                    case "Winter":
                        priceForKm = 1.45;
                        break;
                }
            }
            double salary = km * priceForKm * 4;
            salary -= salary * 0.10;
            Console.WriteLine($"{salary:F2}");
        }
    }
}
