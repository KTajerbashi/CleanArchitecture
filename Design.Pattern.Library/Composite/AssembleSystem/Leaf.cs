namespace Design.Pattern.Library.Composite.AssembleSystem
{
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
}
