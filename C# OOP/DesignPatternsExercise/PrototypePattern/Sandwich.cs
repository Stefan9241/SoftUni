﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread,string meat,string cheese,string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        public override SandwichPrototype Clone()
        {
            string ingridientsList = this.GetIngridientsList();
            Console.WriteLine($"Cloning sandwich with ingieinds {ingridientsList}");
            return this.MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngridientsList()
        {
            return $"{this.bread} {this.meat} {this.cheese} {this.veggies}";
        }
    }
}
