namespace CleanArchitecture.Core.Domain.Library.Common;

public interface IEntity<TKey>
{
    TKey Id { get; }
    Guid EntityId { get; }
  
}
