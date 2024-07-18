using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.BaseApplication.Repositories;

public interface IBaseRepository<TEntity, TId> : IUnitOfWork
    where TEntity : IEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    #region Insert
    /// <summary>
    /// داده‌های جدید را به دیتابیس اضافه می‌کند
    /// </summary>
    /// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
    void Insert(TEntity entity);

    /// <summary>
    /// داده‌های جدید را به دیتابیس اضافه می‌کند
    /// </summary>
    /// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
    Task InsertAsync(TEntity entity);
    #endregion

    #region Update
    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    void Update(TEntity entity, TId id);


    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity, TId id);
    #endregion

    #region Delete
    /// <summary>
    /// یک شی را با شناسه حذف می کند
    /// </summary>
    /// <param name="id">شناسه</param>
    void Delete(TId id);

    /// <summary>
    /// حذف یک شی به همراه تمامی فرزندان آن را انجام می دهد
    /// </summary>
    /// <param name="id">شناسه</param>
    void DeleteGraph(TId id);

    /// <summary>
    /// یک شی را دریافت کرده و از دیتابیس حذف می‌کند
    /// </summary>
    /// <param name="entity"></param>
    void Delete(TEntity entity);
    #endregion

    #region AddOrUpdate
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    void AddOrUpdate(TEntity entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddOrUpdateAsync(TEntity entity);
    #endregion

    #region Get
    /// <summary>
    /// یک شی را با شناسه از دیتابیس یافته و بازگشت می‌دهد.
    /// </summary>
    /// <param name="id">شناسه شی مورد نیاز</param>
    /// <returns>نمونه ساخته شده از شی</returns>
    TEntity Get(TId id);
    Task<TEntity> GetAsync(TId id);

    TEntity Get(BusinessId businessId);
    Task<TEntity> GetAsync(BusinessId businessId);
    #endregion

    #region GetList
    #endregion

    #region Graph
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetGraph(TId id);
    
    /// <summary>
    /// /
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetGraphAsync(TId id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    TEntity GetGraph(BusinessId businessId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    Task<TEntity> GetGraphAsync(BusinessId businessId);
    #endregion

    bool Exists(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}
