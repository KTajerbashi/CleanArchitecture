using Domain.Library.Bases.Interfaces;

namespace Domain.Library.Bases.Services
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DeletedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
