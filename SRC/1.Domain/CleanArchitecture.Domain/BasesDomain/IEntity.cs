using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.BasesDomain;

public interface IEntity<T>
{
    T Id { get; set; }
    Guid Key { get; set; }
}
public abstract class Entity<T> : IEntity<T>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
    public Guid Key { get; set; }
}

public abstract class Entity : Entity<long>
{
}

public abstract class GeneralEntity : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
}