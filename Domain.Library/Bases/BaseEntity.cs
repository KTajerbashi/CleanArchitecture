using System.Numerics;

namespace Domain.Library
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T ID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DeletedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
