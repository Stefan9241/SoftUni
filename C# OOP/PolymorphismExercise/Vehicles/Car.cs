using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airContioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.AirConditioners = airContioner;
        }
    }
}
