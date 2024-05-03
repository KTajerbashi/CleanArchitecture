namespace Design.Pattern.Library.Composite.AssembleSystem
{
    public interface IComponent
    {
        string Name { get; set; }
        int Price { get; set; }
        int DisplayPrice();
    }

    public class Leaf : IComponent
    {
        public string Name { get ; set ; }
        public int Price { get ; set ; }
        public Leaf(string name,int price)
        {
            Name = name;
            Price = price;
        }

        public int DisplayPrice()
        {
            Console.WriteLine($"{Name} : {Price}");
            return Price;
        }
    }
    public class Composite : IComponent
    {
        public string Name { get; set; }
        public int Price { get; set; }
        List<IComponent> Components = new List<IComponent>();

        public Composite(string name,int price)
        {
            Name=name;
            Price = price;
        }

        public void AddComponent(IComponent component)
        {
            Components.Add(component);
        }
        public int DisplayPrice()
        {
            int sum = Price;
            foreach (var item in Components)
            {
                sum += item.DisplayPrice();
            }
            Console.WriteLine($"{Name} : {sum}");
            return sum;
        }
    }
}
