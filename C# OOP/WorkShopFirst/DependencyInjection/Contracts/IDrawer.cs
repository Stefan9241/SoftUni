using DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface IDrawer
    {
        void DrawAtPosition(Position position, string toDraw);
    }
}
