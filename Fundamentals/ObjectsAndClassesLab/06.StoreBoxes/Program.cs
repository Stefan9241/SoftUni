using System;
using System.Collections.Generic;

namespace _06.StoreBoxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public Box(string serialNumber, string itemName, int itemQuant, decimal priceBox, decimal itemPrice)
        {
            SerialNumber = serialNumber;
            Item.Name = itemName;
            Quantity = itemQuant;
            PriceBox = priceBox;
            Item.Price = itemPrice;
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                string serialNumber = command[0];
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                decimal itemPrice = decimal.Parse(command[3]);
                decimal priceOfOneBox = itemPrice * itemQuantity;

                Box current = new Box(serialNumber, itemName, itemQuantity, priceOfOneBox, itemPrice);
                boxList.Add(current);
                command = Console.ReadLine().Split();
            }
        }
    }
}
