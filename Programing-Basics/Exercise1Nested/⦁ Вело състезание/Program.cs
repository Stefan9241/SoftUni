using System;

namespace __Вело_състезание
{
    class Program
    {
        static void Main(string[] args)
        {
            int junior = int.Parse(Console.ReadLine());
            int senior = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            double juniorTax = 0;
            double seniorTax = 0;

            if (type =="trail")
            {
                juniorTax = 5.50;
                seniorTax = 7;
            }
            else if (type == "cross-country")
            {
                juniorTax = 8;
                seniorTax = 9.50;
            }
            else if (type == "downhill")
            {
                juniorTax = 12.25;
                seniorTax = 13.75;
            }
            else if (type == "road")
            {
                juniorTax = 20;
                seniorTax = 21.50;
            }

            int totalPeople = senior + junior;
            
            if (type == "cross-country" && totalPeople >=50 )
            {
                juniorTax -= juniorTax * 0.25;
                seniorTax -= seniorTax * 0.25;
                
            }
            double totalSum = junior * juniorTax + senior * seniorTax;
            totalSum -= totalSum * 0.05;
            Console.WriteLine($"{totalSum:F2}");

        }
    }
}
