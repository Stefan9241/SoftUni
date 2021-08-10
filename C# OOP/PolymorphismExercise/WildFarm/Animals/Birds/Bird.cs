using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, HashSet<string> allowedFoods, double weightModifier,double wingsize) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            WingSize = wingsize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {WingSize}, {base.Weight}, {FoodEaten}]";
        }
    }
}
