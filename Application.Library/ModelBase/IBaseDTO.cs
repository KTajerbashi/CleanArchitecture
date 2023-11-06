using System.ComponentModel;

namespace Application.Library.ModelBase
{
    public interface IBaseDTO
    {
    }
    public abstract class BaseDTO<T> : IBaseDTO
    {
        public Guid Guid { get; set; }
        public T ID { get; set; }
    }
    public abstract class BaseDTO : BaseDTO<long>
    {
        public string Key { get; set; }
    }
    public class ResultPublicDTO<T>
    {
        public int? Count { get; set; }
        public string Message { get; set; }
        public T? Result { get; set; }
    }
    public class ResultBaseDTO<T> : ResultPublicDTO<T>
       where T : IBaseDTO
    {
    }
}
