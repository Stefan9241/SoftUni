using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods,double weightModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }
        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; } = 0;

        public abstract string ProducingSound();

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;

            this.Weight += WeightModifier * food.Quantity; 
        }
    }
}
