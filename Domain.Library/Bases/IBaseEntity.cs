namespace Domain.Library
{
    public interface IBaseEntity<T>
    {
        T ID { get; set; }
    }
}
