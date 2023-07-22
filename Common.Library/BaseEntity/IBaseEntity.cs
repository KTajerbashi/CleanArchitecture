namespace Domain.Library
{
    public interface IBaseEntity<T>
    {
        T ID { get; set; }
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T ID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public T CreateBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public T DeletedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public T UpdatedBy { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
