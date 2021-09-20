﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Foods
    {
        private const char FoodSymbol = '*';
        private const int Points = 1;
        public FoodAsterisk(Wall wall) 
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
