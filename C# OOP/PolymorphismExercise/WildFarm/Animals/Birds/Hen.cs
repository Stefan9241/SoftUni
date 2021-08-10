using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;

        private static HashSet<string> allowedOwlFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };
        public Hen(string name, double weight,  double wingsize) 
            : base(name, weight, allowedOwlFoods, BaseWeightModifier, wingsize)
        {
        }

        public override string ProducingSound()
        {
            return "Cluck";
        }
    }
}
