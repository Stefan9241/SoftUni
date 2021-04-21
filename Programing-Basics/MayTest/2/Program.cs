using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Бюджет – реално число в интервала[0.00… 10000.00]
            //Колко литра гориво ще са им нужни – реално число в интервала[1.00… 50.00]
            //Ден от седмицата – текст с възможности "Saturday" и "Sunday"

            double budget = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double fuelAndAGuy = 2.10 * fuel + 100;
            if (dayOfWeek == "Saturday")
            {
                fuelAndAGuy -= fuelAndAGuy * 0.10;
            }
            else
            {
                fuelAndAGuy -= fuelAndAGuy * 0.20;
            }
            if (budget >= fuelAndAGuy)
            {
                Console.WriteLine($"Safari time! Money left: {budget - fuelAndAGuy:F2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {Math.Abs(fuelAndAGuy - budget):F2} lv.");
            }
        }
    }
}
