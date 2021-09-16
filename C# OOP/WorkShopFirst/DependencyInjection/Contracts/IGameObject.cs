using DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface IGameObject : IDrawable
    {
        Position Position { get;}
    }
}
