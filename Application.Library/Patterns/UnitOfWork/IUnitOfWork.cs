using Application.Library.ModelBase;
using Domain.Library.BasesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Patterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        IRepository<TEntity> CreateRepository<TEntity>() where TEntity : IBaseDTO;
        IRepository<TEntity> RemoveRepository<TEntity>() where TEntity : IBaseDTO;
        IRepository<TEntity> UpdateRepository<TEntity>() where TEntity : IBaseDTO;
        IRepository<IEnumerable<TEntity>> GetAllRepository<TEntity>() where TEntity : IBaseDTO;
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : IBaseDTO;
    }
}
