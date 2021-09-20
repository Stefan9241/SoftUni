﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Foods
    {
        private const char FoodSymbol = '$';
        private const int Points = 2;
        public FoodDollar(Wall wall) 
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
