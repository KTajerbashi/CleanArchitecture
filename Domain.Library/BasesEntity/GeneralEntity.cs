namespace Domain.Library.BasesEntity
{
    public abstract class GeneralEntity : BaseEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
