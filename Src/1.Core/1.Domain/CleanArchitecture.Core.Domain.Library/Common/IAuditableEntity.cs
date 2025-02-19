namespace CleanArchitecture.Core.Domain.Library.Common;

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
