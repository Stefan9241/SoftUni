using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern.DrawingComponents
{
    class Text : Component
    {
        public Text(Position position,string text) : base(position) 
        {
            TextToDraw = text;
        }

        public string TextToDraw { get; set; }
        public override void Draw()
        {
            Console.SetCursorPosition(Position.X,Position.Y);
            Console.WriteLine(TextToDraw);
            base.Draw();
        }
    }
}
