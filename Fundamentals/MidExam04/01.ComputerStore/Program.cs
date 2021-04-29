using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string client = string.Empty;
            double priceWithoutTax = 0;
            while (true)
            {
                if (command == "special")
                {
                    client = command;
                    break;
                }
                else if (command == "regular")
                {
                    client = command;
                    break;
                }
                double currPrice = double.Parse(command);
                if (currPrice <= 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }
                priceWithoutTax += currPrice;

                command = Console.ReadLine();
                
            }
            if (priceWithoutTax <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            double tax = priceWithoutTax * 0.20;
            double totalPrice = priceWithoutTax + tax;
            if (client == "special")
            {
                totalPrice -= totalPrice * 0.10;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceWithoutTax:f2}$");
            Console.WriteLine($"Taxes: {tax:F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}
