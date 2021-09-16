using DependencyInjection.Common;
using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Movers
{
    public class SlowMover : IMover
    {
        public void Move(IGameObject gameObject, Position position)
        {
            gameObject.Position.X += position.X;
            gameObject.Position.Y += position.Y;
        }
    }
}
