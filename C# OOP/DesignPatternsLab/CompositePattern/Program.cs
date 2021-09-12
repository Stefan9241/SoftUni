using System;
using System.Threading;
using CompositePattern.DrawingComponents;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent page = new Component(new Position(0, 0));

            page.Add(new Rectangle(new Position(45, 10), 10));

            IComponent rec = (new Rectangle(new Position(15, 5), 10));
            rec.Add(new Text(new Position(25, 5), "Composite Is Cool"));

            page.Add(rec);

            rec.Move(new Position(0,10));
            page.Draw();

            while (true)
            {
                Position movePosition = new Position(1, 1);
                Console.Clear();
                rec.Move(movePosition);
                rec.Draw();

                Thread.Sleep(500);
            }
        }
    }
}
