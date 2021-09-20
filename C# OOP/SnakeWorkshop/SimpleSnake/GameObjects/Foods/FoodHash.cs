using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Foods
    {
        private const char FoodSymbol = '#';
        private const int Points = 3;
        public FoodHash(Wall wall) 
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
