using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.BasesEntity
{
    
    public abstract class BaseEntity<T> : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T ID { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
    public abstract class BaseEntity : BaseEntity<long>
    {
        public long CreateBy { get; set; }
        public long DeletedBy { get; set; }
        public long UpdatedBy { get; set; }
    }
}
