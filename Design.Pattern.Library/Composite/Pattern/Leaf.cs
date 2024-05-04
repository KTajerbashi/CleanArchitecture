namespace Design.Pattern.Library.Composite.Pattern
{
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
