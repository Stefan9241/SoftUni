using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Foods : Point
    {
        private char foodSymbol;
        private readonly Random random;
        private readonly Wall wallInfo;
        protected Foods(Wall wall,char foodSymbol,int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wallInfo = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snameElements)
        {
            this.LeftX = random.Next(2, wallInfo.LeftX - 2);
            this.TopY = random.Next(2, wallInfo.TopY - 2);

            bool isPointOfSnake = snameElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wallInfo.LeftX - 2);
                this.TopY = random.Next(2, this.TopY - 2);

                isPointOfSnake = snameElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return this.LeftX == snakeHead.LeftX && snakeHead.TopY == this.TopY;
        }
    }
}
