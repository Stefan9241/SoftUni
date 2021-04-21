using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Брой пилешки менюта – цяло число в интервала[0… 99]
            //Брой менюта с риба -цяло число в интервала[0… 99]
            //Брой вегетариански менюта - цяло число в интервала[0… 99]
            int numChickenMenu = int.Parse(Console.ReadLine());
            int numFishMenu = int.Parse(Console.ReadLine());
            int numVeganMenu = int.Parse(Console.ReadLine());

            double chicken = numChickenMenu * 10.35;
            double fish = numFishMenu * 12.40;
            double vegan = numVeganMenu * 8.15;
            double sum = chicken + fish + vegan;
            double desert = sum * 0.20;
            double total = sum + desert + 2.50;
            Console.WriteLine($"Total: { total:f2}");
        }
    }
}
