using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class Component : IComponent
    {
        private List<IComponent> children;
        public Position Position { get; set; }
        public Component(Position position)
        {
            children = new List<IComponent>();
            Position = position;
        }
        public void Add(IComponent component)
        {
            this.children.Add(component);
        }

        public void Remove(IComponent component)
        {
            children.Remove(component);
        }
        public virtual void Draw()
        {
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public virtual void Move(Position position)
        {
            position.X += position.X;
            position.Y += position.Y;
            foreach (var child in children)
            {
                child.Move(position);
            }
        }

    }
}
