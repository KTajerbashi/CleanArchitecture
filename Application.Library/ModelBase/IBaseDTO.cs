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
}
