using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBaseService<IEntity, TEntity, VEntity>
    {
        bool Insert(IEntity entity);
        IEntity Read(int id);
        bool Update(IEntity entity);
        bool Delete(IEntity entity);
        bool Delete(int id);
        IEnumerable<IEntity> Read();
    }
}
