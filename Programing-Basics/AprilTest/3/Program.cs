using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първи ред -дестинация - текст с възможности"France", "Italy" или "Germany"
            //Втори ред -дати, през които си е резервирала екскурзията -текст  с възможности "21-23", 
            //"24-27" или "28-31"
            //Трети ред -брой нощувки - цяло число в интервала[1… 100]

            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numNights = int.Parse(Console.ReadLine());
            double priceForNight = 0;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    priceForNight = 30;
                }
                else if (dates == "24-27")
                {
                    priceForNight = 35;
                }
                else if (dates == "28-31")
                {
                    priceForNight = 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    priceForNight = 28;
                }
                else if (dates == "24-27")
                {
                    priceForNight = 32;
                }
                else if (dates == "28-31")
                {
                    priceForNight = 39;
                }
            }
            else if ( destination == "Germany")
            {
                if (dates == "21-23")
                {
                    priceForNight = 32;
                }
                else if (dates == "24-27")
                {
                    priceForNight = 37;
                }
                else if (dates == "28-31")
                {
                    priceForNight = 43;
                }
            }
            double sum = priceForNight * numNights;

            Console.WriteLine($"Easter trip to {destination} : {sum:F2} leva.");
        }
    }
}
