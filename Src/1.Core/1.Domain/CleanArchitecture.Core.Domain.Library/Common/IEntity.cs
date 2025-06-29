using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Core.Domain.Library.Common;

public interface IEntity<TKey>
{
    TKey Id { get; }
    EntityId EntityId { get; }

}
public abstract class Entity<TKey> : IEntity<TKey>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; protected set; }
    public EntityId EntityId { get; } = Guid.NewGuid();

    protected Entity() => _domainEvents = new();


    private readonly List<BaseEvent> _domainEvents;
    public IEnumerable<IEvent> GetEvents() => _domainEvents;

    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

}

public interface IAuditableEntity<TKey> : IEntity<TKey>
     where TKey : struct,
          IComparable,
          IComparable<TKey>,
          IConvertible,
          IEquatable<TKey>,
          IFormattable
{
    bool IsDeleted { get; }
    bool IsActive { get; }
    void Delete();
    void Access();
    DateTime CreatedDate { get; }
    TKey CreatedByUserRoleId { get; }
    DateTime? UpdatedDate { get; }
    TKey? UpdatedByUserRoleId { get; }
}
public abstract class BaseAuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
    where TKey : struct,
          IComparable,
          IComparable<TKey>,
          IConvertible,
          IEquatable<TKey>,
          IFormattable
{
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public void Access()
    {
        IsActive = true;
        IsDeleted = false;
    }
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
    public DateTime CreatedDate { get; }

    public TKey CreatedByUserRoleId { get; }

    public DateTime? UpdatedDate { get; }

    public TKey? UpdatedByUserRoleId { get; }
}
public abstract class BaseAuditableEntity : BaseAuditableEntity<long>
{

}