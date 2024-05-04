namespace Design.Pattern.Library.Composite.AssembleSystem
{
    public interface IComponent
    {
        string Name { get; set; }
        int Price { get; set; }
        int DisplayPrice();
    }
}
