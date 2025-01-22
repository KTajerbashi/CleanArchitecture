using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication;

public interface IBaseService<TEntity, TId> where TEntity : class, IAuditableEntity
{
}
