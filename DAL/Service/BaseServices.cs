using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class BaseServices<TEntity>
        where TEntity : class
    {
        //ApplicationContextBase DB;

        //public BaseServices(ApplicationContextBase context)
        //{
        //    DB = context;
        //}
        //public async Task<bool> Add(TEntity entity)
        //{
        //    try
        //    {
        //        DB.Set<TEntity>().Add(entity);
        //        await DB.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public async Task<bool> Update(TEntity entity)
        //{
        //    try
        //    {
        //        DB.Set<TEntity>().Update(entity);
        //        await DB.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public async Task<bool> Delete(int id)
        //{
        //    try
        //    {
        //        DB.Set<TEntity>().Remove(DB.Set<TEntity>().Find(id));
        //        await DB.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public async Task<TEntity> Read(int id)
        //{
        //    return DB.Set<TEntity>().Find(id);
        //}

        //public async Task<IEnumerable<TEntity>> Read()
        //{
        //    return DB.Set<TEntity>().ToList();
        //}

    }
}
