﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RaceMotorcycleConsumption = 8;
        public RaceMotorcycle(int hp, double fuel) 
            : base(hp, fuel)
        {

        }
        public override double FuelConsumption => RaceMotorcycleConsumption;
    }

}
