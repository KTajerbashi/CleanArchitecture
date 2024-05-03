using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Pattern.Library.Composite
{
    public abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);
        public abstract void Update(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        public List<Component> Components { get; set; } = new List<Component>();
        public Composite(string name) : base(name)
        {
        }
        public Composite(string name, Component[] components) : base(name)
        {
            foreach (var item in components)
            {
                Add(item);
            }
        }
        public override void Add(Component component)
        {
            Components.Add(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
            foreach (var item in Components)
            {
                item.Display(depth + 2);
            }
        }

        public override void Remove(Component component)
        {
            Components.Remove(component);
        }

        public override void Update(Component component)
        {
            Components.Add(component);
        }
    }

    public class Leaf : Component
    {
        public List<Component> Components { get; set; } = new List<Component>();
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Update(Component component)
        {
            throw new NotImplementedException();
        }
    }

}
