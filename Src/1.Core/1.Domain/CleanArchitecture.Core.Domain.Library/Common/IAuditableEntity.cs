namespace CleanArchitecture.Core.Domain.Library.Common;

public interface IAuditableEntity<TKey> : IEntity<TKey>
{
    DateTime CreatedDate { get; }
    TKey CreatedByUserRoleId { get; }
    DateTime? UpdatedDate { get; }
    TKey? UpdatedByUserRoleId { get; }
}
