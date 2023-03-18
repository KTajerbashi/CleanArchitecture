using DAL.Data;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class BaseService<TEntity, IEntity> : IBaseService<TEntity, IEntity>
        where TEntity : class
        where IEntity : class
    {
        ApplicationContextBase _applicationContext;

        public BaseService() => _applicationContext = new ApplicationContextBase();


        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _applicationContext.Set<TEntity>().Remove(entity);
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity en = _applicationContext.Set<TEntity>().Find(id);
            return en;
        }

        public async Task<bool> Insert(TEntity entity)
        {
            try
            {
                _applicationContext.Set<TEntity>().Add(entity);
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TEntity> Read(int id)
        {
            return _applicationContext.Set<TEntity>().Find(id);
        }

        public async Task<IEnumerable<TEntity>> Read()
        {
            return _applicationContext.Set<TEntity>().ToList();
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _applicationContext.Entry<TEntity>(entity).State = EntityState.Modified;
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
