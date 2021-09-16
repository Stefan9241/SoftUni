using DependencyInjection.Common;
using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Movers
{
    class FastMover : IMover
    {
        public void Move(IGameObject gameObject, Position position)
        {
            gameObject.Position.X += position.X * 4;
            gameObject.Position.Y += position.Y * 4;
        }
    }
}
