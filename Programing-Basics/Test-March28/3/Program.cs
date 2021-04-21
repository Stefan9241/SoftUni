using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setSize = Console.ReadLine();
            int numSets = int.Parse(Console.ReadLine());
            double priceForOne = 0;
            switch (fruit)
            {
                case "Watermelon":
                    switch (setSize)
                    {
                        case "small":
                            priceForOne = 56 * 2;
                            break;
                        case "big":
                            priceForOne = 28.70 * 5;
                            break;
                    }
                    break;
                case "Mango":
                    switch (setSize)
                    {
                        case "small":
                            priceForOne = 36.66 * 2;
                            break;
                        case "big":
                            priceForOne = 19.60 * 5;
                            break;
                    }
                    break;
                case "Pineapple":
                    switch (setSize)
                    {
                        case "small":
                            priceForOne = 42.10 * 2;
                            break;
                        case "big":
                            priceForOne = 24.80 * 5;
                            break;
                    }
                    break;
                case "Raspberry":
                    switch (setSize)
                    {
                        case "small":
                            priceForOne = 20 * 2;
                            break;
                        case "big":
                            priceForOne = 15.20 * 5;
                            break;
                    }
                    break;
            }
            double sum = priceForOne * numSets;
            if (sum >= 400 && sum <= 1000)
            {
                sum -= sum * 0.15;
            }
            else if (sum > 1000)
            {
                sum = sum / 2;
            }

            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
