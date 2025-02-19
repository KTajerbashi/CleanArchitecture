namespace CleanArchitecture.Core.Domain.Library.Common;

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