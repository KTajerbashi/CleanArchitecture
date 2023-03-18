using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public interface IBaseService<TEntity,IEntity>
    {
        Task<bool> Insert(TEntity entity);
        Task<TEntity> Read(int id);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<IEnumerable<TEntity>> Read();
    }
}
