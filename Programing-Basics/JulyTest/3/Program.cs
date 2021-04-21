using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numJoynery = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string delivery = Console.ReadLine();
            if (numJoynery < 10)
            {
                Console.WriteLine($"Invalid order");
                return;
            }
            double priceForOne = 0;
            if (type == "90X130")
            {
                priceForOne = 110 * numJoynery;
                if (numJoynery > 30 &&  numJoynery <= 60)
                {
                    priceForOne -= priceForOne * 0.05;
                }
                else if (numJoynery > 60)
                {
                    priceForOne -= priceForOne * 0.08;
                }
            }
            else if (type == "100X150")
            {
                priceForOne = 140 * numJoynery;
                if (numJoynery > 40 && numJoynery <= 80)
                {
                    priceForOne -= priceForOne * 0.06;
                }
                else if (numJoynery > 80)
                {
                    priceForOne -= priceForOne * 0.10;
                }
            }
            else if (type == "130X180")
            {
                priceForOne = 190 * numJoynery;
                if (numJoynery > 20 && numJoynery <= 50)
                {
                    priceForOne -= priceForOne * 0.07;
                }
                else if (numJoynery > 50)
                {
                    priceForOne -= priceForOne * 0.12;
                }
            }
            else if (type == "200X300")
            {
                priceForOne = 250;
                if (numJoynery > 25 && numJoynery <= 50)
                {
                    priceForOne -= priceForOne * 0.09;
                }
                else if (numJoynery > 50)
                {
                    priceForOne -= priceForOne * 0.14;
                }
            }
            
            if (delivery == "With delivery")
            {
                priceForOne += 60;
            }
            if (numJoynery > 99)
            {
                priceForOne -= priceForOne * 0.04;
            }
            
            Console.WriteLine($"{priceForOne:f2} BGN");
        }
    }
}
