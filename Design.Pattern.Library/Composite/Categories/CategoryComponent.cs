namespace Design.Pattern.Library.Composite.Categories
{
    /// <summary>
    /// Category Component
    /// </summary>
    public abstract class CategoryComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string Print()
        {
            return Name;
        }

        public abstract void Add(CategoryComponent component);
        public abstract void Remove(CategoryComponent component);
    }

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

    /// <summary>
    /// Category Item
    /// </summary>
    public class CategoryItemLeaf : CategoryComponent
    {
        public string Link { get; set; }
        public CategoryItemLeaf(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public CategoryItemLeaf()
        {}
        public override void Add(CategoryComponent component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(CategoryComponent component)
        {
            throw new NotImplementedException();
        }
        public override string Print()
        {
            return base.Print();
        }
    }
}
