using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BaseService<IEntity,TEntity> : IBaseService<IEntity, IViewModel, IListViewModel>
    {
        public bool Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
