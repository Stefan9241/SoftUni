using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string device = Console.ReadLine();
            double hard = 0;
            double play = 0;

            switch (country)
            {
                case "Russia":
                    switch (device)
                    {
                        case "ribbon":
                            hard = 9.100;
                            play = 9.400;
                            break;
                        case "hoop":
                            hard = 9.300;
                            play = 9.800;
                            break;
                        case "rope":
                            hard = 9.600;
                            play = 9.000;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (device)
                    {
                        case "ribbon":
                            hard = 9.600;
                            play = 9.400;
                            break;
                        case "hoop":
                            hard = 9.550;
                            play = 9.750;
                            break;
                        case "rope":
                            hard = 9.500;
                            play = 9.400;
                            break;
                    }
                    break;
                case "Italy":
                    switch (device)
                    {
                        case "ribbon":
                            hard = 9.200;
                            play = 9.500;
                            break;
                        case "hoop":
                            hard = 9.450;
                            play = 9.350;
                            break;
                        case "rope":
                            hard = 9.700;
                            play = 9.150;
                            break;
                    }
                    break;
            }
            double valuetion = hard + play;
            double score = 20 - valuetion;
            double pointsPercent = (score / 20) * 100;

            Console.WriteLine($"The team of {country} get {valuetion:F3} on {device}.");
            Console.WriteLine($"{pointsPercent:F2}%");
        }
    }
}
