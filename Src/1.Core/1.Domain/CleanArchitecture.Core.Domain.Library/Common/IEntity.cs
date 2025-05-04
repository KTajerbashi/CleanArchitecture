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
