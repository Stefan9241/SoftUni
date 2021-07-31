using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaultGrams = 250;
        private const double DefaultCals = 1000;
        private const decimal DefaultPrice = 5m;
        public Cake(string name) 
            : base(name, DefaultPrice, DefaultGrams, DefaultCals)
        {
        }
    }
}
