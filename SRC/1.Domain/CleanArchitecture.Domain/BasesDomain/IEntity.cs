using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;

namespace CleanArchitecture.Domain.BasesDomain;

public interface IEntity<T>
{
    T Id { get; set; }
    BusinessId Key { get; set; }
}
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public BusinessId Key { get; set; }
}

public abstract class Entity : Entity<long>
{
}

public abstract class GeneralEntity : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
}