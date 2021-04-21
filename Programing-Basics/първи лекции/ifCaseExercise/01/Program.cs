using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string project = Console.ReadLine();
            double numRows = double.Parse(Console.ReadLine());
            double numColumns = double.Parse(Console.ReadLine());
            double price = 0;
            switch (project)
            {
                case "Premiere":
                    price = 12;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.00;
                    break;
            }
            double totalPrice = (numRows * numColumns) * price;
            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
