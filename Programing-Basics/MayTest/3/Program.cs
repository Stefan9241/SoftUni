using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Срок на договор – текст – "one", или "two"
            //Тип на договор – текст – "Small",  "Middle", "Large"или "ExtraLarge"
            //Добавен мобилен интернет – текст – "yes" или "no"
            //Брой месеци за плащане -цяло число в интервала[1 … 24]
            string time = Console.ReadLine();
            string type = Console.ReadLine();
            string internet = Console.ReadLine();
            int numMonths = int.Parse(Console.ReadLine());

            double priceForMonth = 0;
            switch (time)
            {
                case "one":
                    if (type == "Small")
                    {
                        priceForMonth = 9.98;
                    }
                    else if (type == "Middle")
                    {
                        priceForMonth = 18.99;
                    }
                    else if (type == "Large")
                    {
                        priceForMonth = 25.98;
                    }
                    else if (type == "ExtraLarge")
                    {
                        priceForMonth = 35.99;
                    }
                    break;
                case "two":
                    if (type == "Small")
                    {
                        priceForMonth = 8.58;
                    }
                    else if (type == "Middle")
                    {
                        priceForMonth = 17.09;
                    }
                    else if (type == "Large")
                    {
                        priceForMonth = 23.59;
                    }
                    else if (type == "ExtraLarge")
                    {
                        priceForMonth = 31.79;
                    }
                    break;
            }
            if (internet == "yes")
            {
                if (priceForMonth <= 10)
                {
                    priceForMonth += 5.50;
                }
                else if (priceForMonth > 10 && priceForMonth <= 30)
                {
                    priceForMonth += 4.35;
                }
                else
                {
                    priceForMonth += 3.85;
                }
            }
            double totalPrice = priceForMonth * numMonths;
            if (time == "two")
            {
                totalPrice -= totalPrice * 0.0375;
            }

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
