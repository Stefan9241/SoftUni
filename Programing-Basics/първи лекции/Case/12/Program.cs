using System;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commision = 0;
            if (city == "Plovdiv")
            {

                if (0 <= sales && sales <= 500) commision = 0.055;

                else if (500 < sales && sales <= 1000) commision = 0.08;

                else if (1000 < sales && sales <= 10000) commision = 0.12;

                else if (sales > 10000) commision = 0.145;
            }
            else if (city == "Sofia")
            {
                if (0 <= sales && sales <= 500) commision = 0.050;

                else if (500 < sales && sales <= 1000) commision = 0.07;

                else if (1000 < sales && sales <= 10000) commision = 0.08;

                else if (sales > 10000) commision = 0.12;
            }
            else if (city == "Varna")
            {
                if (0 <= sales && sales <= 500) commision = 0.045;

                else if (500 < sales && sales <= 1000) commision = 0.075;

                else if (1000 < sales && sales <= 10000) commision = 0.10;

                else if (sales > 10000) commision = 0.13;
            }
            if (city =="Plovdiv" && sales >=0 || city =="Varna" && sales>=0 || city =="Sofia" && sales >= 0)
            {
                Console.WriteLine($"{sales * commision:f2}");
            }
            else if (sales < 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
