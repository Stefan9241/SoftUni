using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double AirConditioners { get; set; } = 0;
        public double TankCapacity { get; set; }
        public void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + AirConditioners) * distance;
            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            if (amount + FuelQuantity > TankCapacity)
            {
                throw new Exception($"Cannot fit {amount} fuel in the tank");
            }

            if (this.GetType().Name == nameof(Truck))
            {
                this.FuelQuantity += amount * 0.95;
            }
            else
            {
                this.FuelQuantity += amount;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
