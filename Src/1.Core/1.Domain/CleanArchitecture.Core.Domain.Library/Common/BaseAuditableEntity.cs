namespace CleanArchitecture.Core.Domain.Library.Common;

public abstract class BaseAuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
{
    public DateTime CreatedDate { get; }

    public TKey CreatedByUserRoleId { get; }

    public DateTime? UpdatedDate { get; }

    public TKey? UpdatedByUserRoleId { get; }
}

public abstract class BaseAuditableEntity : BaseAuditableEntity<long>
{

}