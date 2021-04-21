using System;

namespace Резервоар_за_гориво____част_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            string cardOrNo = Console.ReadLine();

            double discount = 0;
            double fuel = 0;
            double sum = 0;

            if (cardOrNo == "Yes")
            {
                switch (text)
                {
                    case "Gas":
                        discount += 0.08;
                        fuel += 0.93;
                        break;
                    case "Diesel":
                        discount += 0.12;
                        fuel += 2.33;
                        break;
                    case "Gasoline":
                        discount += 0.18;
                        fuel += 2.22;
                        break;
                }
                sum = quantity * fuel - (quantity * discount);
            }
            else
            {
                switch (text)
                {
                    case "Gas":
                        fuel += 0.93;
                        break;
                    case "Diesel":
                        fuel += 2.33;
                        break;
                    case "Gasoline":
                        fuel += 2.22;
                        break;
                }

                sum = quantity * fuel;
            }

            if (quantity >= 20 && quantity <= 25)
            {
                sum -= sum * 0.08;
            }
            else if (quantity > 25)
            {
                sum -= sum * 0.10;
            }
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
