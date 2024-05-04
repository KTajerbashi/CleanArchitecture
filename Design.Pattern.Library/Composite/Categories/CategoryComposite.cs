namespace Design.Pattern.Library.Composite.Categories
{
    /// <summary>
    /// Category
    /// </summary>
    public class CategoryComposite : CategoryComponent
    {
        public CategoryComposite(string name)
        {
            Name = name;
        }
        readonly List<CategoryComponent>  CategoryComponent = new List<CategoryComponent>();
        public ICollection<CategoryComponent> Categories => CategoryComponent;

        public CategoryComposite() { }

        public override void Add(CategoryComponent component)
        {
            CategoryComponent.Add(component);
        }

        public override void Remove(CategoryComponent component)
        {
            CategoryComponent.Remove(component);
        }

        public override string Print()
        {
            return "";
        }
    }
}
