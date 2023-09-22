namespace Domain.Library
{
    public interface IBaseEntity<T>
    {
        T ID { get; set; }
        Guid Guid { get; set; }
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T ID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public T CreateBy { get; set; }
        public DateTime DeletedDate { get; set; } = DateTime.Now;
        public T DeletedBy { get; set; } 
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public T UpdatedBy { get; set; } 
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
