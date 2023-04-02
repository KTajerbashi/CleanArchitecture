using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IRdsCrudService<IEntity, TEntity, VEntity>
        where IEntity : class
        where TEntity : class
        where VEntity : class
    {
        Task<bool> Insert(TEntity entity);
        Task<TEntity> Read(int id);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<TEntity>> Read();
    }
}
