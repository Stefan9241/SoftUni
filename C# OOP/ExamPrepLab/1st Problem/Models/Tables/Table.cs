using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            this.isReserved = false;
        }
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved => this.isReserved;

        public decimal Price => numberOfPeople * PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            isReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = 0;
            foreach (var foodPriceinfo in foodOrders)
            {
                bill += foodPriceinfo.Price;
            }

            foreach (var drinkPriceInfo in drinkOrders)
            {
                bill += drinkPriceInfo.Price;
            }

            return bill;
        }

        public string GetFreeTableInfo()
        {
            return  $"Table: {this.TableNumber}\r\n\"" +
                    $"Type: {this.GetType().Name}\r\n\"" +
                    $"Capacity: {Capacity}\r\n\"" +
                    $"Price per Person: {PricePerPerson}";

        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.isReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
