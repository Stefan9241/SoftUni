﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight,string livingregion, string breed) 
            : base(name, weight, allowedFoods, BaseWeightModifier, livingregion, breed)
        {
        }

        public override string ProducingSound()
        {
            return "ROAR!!!";
        }
    }
}
