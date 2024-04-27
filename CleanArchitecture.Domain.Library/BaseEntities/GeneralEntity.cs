namespace CleanArchitecture.Domain.Library.BaseEntities
{
    public abstract class GeneralEntity : BaseEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
