using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int SnakeStartLenght = 6;
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySpaceSymbol = ' ';

        private readonly Queue<Point> snakeElements;
        private readonly Foods.Foods[] foods;
        private readonly Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        private bool isSpawned;
        private int snakePoints;
        private int levelCounter;




        public Snake(Wall wall)
        {
            this.snakeElements = new Queue<Point>();
            this.foods = new Foods.Foods[3];
            this.wall = wall;
            this.foodIndex = RandomFoodNumber;
            this.snakePoints = 6;
            this.levelCounter = 100;
            this.isSpawned = false;
            this.GetFoods();
            this.CreateSnake();
        }
        public int SnakePoints => this.snakePoints;
        public int SnakeLevel=> this.levelCounter / 100;

        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);
        private void CreateSnake()
        {
            for (int topY = 1; topY <= SnakeStartLenght; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            this.foods[0] = new Foods.FoodHash(this.wall);
            this.foods[1] = new Foods.FoodDollar(this.wall);
            this.foods[2] = new Foods.FoodAsterisk(this.wall);
        }

        public bool isMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (!this.isSpawned)
            {
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
                this.isSpawned = true;
            }

            if (this.foods[this.foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EmptySpaceSymbol);

            this.levelCounter++;
            return true;
        }

        private void Eat(Point direction,Point currentSnakeHead)
        {
            int lenght = this.foods[foodIndex].FoodPoints;
            for (int i = 0; i < lenght; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);

            }
            this.snakePoints += lenght;
            this.foodIndex = RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);

        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }
    }
}
