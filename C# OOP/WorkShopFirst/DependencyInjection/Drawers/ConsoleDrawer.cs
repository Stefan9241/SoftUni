using DependencyInjection.Common;
using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Drawers
{
    public class ConsoleDrawer : IDrawer
    {
        public void DrawAtPosition(Position position, string toDraw)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(toDraw);
        }
    }
}
