using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double CarConsumption = 3;
        public Car(int hp, double fuel) 
            : base(hp, fuel)
        {
        }

        public override double FuelConsumption => CarConsumption;
    }
}
