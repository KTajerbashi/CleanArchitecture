using System.ComponentModel;

namespace Application.Library.BaseModel.BaseDTO
{
    public interface IBaseDTO
    {
    }
    public class BaseDTO<T> : IBaseDTO
    {
        public T ID { get; set; }
        public Guid Guid { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
        public long? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }
    }
    public class BaseDTO : BaseDTO<long>
    {

    }
    
}
