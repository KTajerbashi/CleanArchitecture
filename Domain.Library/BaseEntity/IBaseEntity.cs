using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.BaseEntity
{
    public interface IBaseEntity
    {
    }
    public abstract class BaseEntity<T>: IBaseEntity
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
    public abstract class GeneralEntity : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
