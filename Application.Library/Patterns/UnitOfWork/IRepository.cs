using Application.Library.ModelBase;
using Domain.Library.BasesEntity;

namespace Application.Library.Patterns.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : IBaseDTO
    {

    }
}
