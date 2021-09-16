using DependencyInjection.Common;
using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.GameObjects
{
    public class Ball : IGameObject
    {
        private IDrawer drawer;
        public Ball(IDrawer drawer)
        {
            Random rnd = new Random();
            this.Position = new Position(rnd.Next(0, 20), rnd.Next(0, 20));
            this.drawer = drawer;
        }
        public Position Position { get; set; }
        public void Draw()
        {
            drawer.DrawAtPosition(Position, "@");
        }
    }
}
