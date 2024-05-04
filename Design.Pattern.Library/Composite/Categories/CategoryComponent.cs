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
}
