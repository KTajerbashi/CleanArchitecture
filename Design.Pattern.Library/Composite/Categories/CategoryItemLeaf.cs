namespace Design.Pattern.Library.Composite.Categories
{
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
