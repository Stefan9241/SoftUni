using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.StoreBoxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
        public double TotalPrice { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();
            string[] command = Console.ReadLine().Split();
            double totalPRice = 0;
            while (command[0] != "end")
            {
                string serialNumber = command[0];
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                double itemPrice = double.Parse(command[3]);
                totalPRice = itemPrice * itemQuantity;

                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.PriceForBox = itemPrice;
                box.TotalPrice = totalPRice;
                boxList.Add(box);
                command = Console.ReadLine().Split();
            }

            List<Box> sortedList = boxList.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedList.Reverse();
            foreach (Box box in sortedList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.PriceForBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.TotalPrice:F2}");

            }

        }
    }
}
