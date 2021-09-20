using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int lefX, int topY) 
            : base(lefX, topY)
        {
            this.InitializeWallBorders();
        }
        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX,topY,WallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }

        public bool IsPointOfWall(Point snakePoint)
        {
            return snakePoint.LeftX == 0 || snakePoint.LeftX == this.LeftX - 1
                || snakePoint.TopY == 0 || snakePoint.TopY == this.TopY;
        }
    }
}
