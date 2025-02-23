using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Core.Domain.Library.Common;

public interface IEntity<TKey>
{
    TKey Id { get; }
    Guid EntityId { get; }

}
public abstract class Entity<TKey> : IEntity<TKey>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; } = default!;
    public Guid EntityId { get; } = Guid.NewGuid();

    private readonly List<BaseEvent> _domainEvents = new();
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

}
