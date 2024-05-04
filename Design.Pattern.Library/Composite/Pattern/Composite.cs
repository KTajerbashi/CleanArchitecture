namespace Design.Pattern.Library.Composite.Pattern
{
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

}
