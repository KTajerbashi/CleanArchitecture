using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Application.BaseApplication.Models.Views;
using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Domain.BasesDomain;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.BaseApplication.Repositories;

public interface IBaseRepository<TEntity, TDTO, TView, TId> : IUnitOfWork
    where TEntity : IEntity<TId>
    where TDTO : IModelDTO<TId>
    where TView : IModelView
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
    bool Insert(TDTO entity);

    /// <summary>
    /// داده‌های جدید را به دیتابیس اضافه می‌کند
    /// </summary>
    /// <param name="entity">نمونه داده‌ای که باید به دیتابیس اضافه شود.</param>
    Task InsertAsync(TDTO entity);
    #endregion

    #region Update
    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    bool Update(TDTO entity);

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    bool Update(TDTO entity, TId id);


    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(TDTO entity);

    /// <summary>
    /// ویرایش اطلاعات
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task UpdateAsync(TDTO entity, TId id);
    #endregion

    #region Delete
    /// <summary>
    /// یک شی را با شناسه حذف می کند
    /// </summary>
    /// <param name="id">شناسه</param>
    bool Delete(TId id);

    /// <summary>
    /// حذف یک شی به همراه تمامی فرزندان آن را انجام می دهد
    /// </summary>
    /// <param name="id">شناسه</param>
    bool DeleteGraph(TId id);

    /// <summary>
    /// یک شی را دریافت کرده و از دیتابیس حذف می‌کند
    /// </summary>
    /// <param name="entity"></param>
    bool Delete(TDTO entity);
    #endregion

    #region AddOrUpdate
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    bool AddOrUpdate(TDTO entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddOrUpdateAsync(TDTO entity);
    #endregion

    #region Get
    /// <summary>
    /// یک شی را با شناسه از دیتابیس یافته و بازگشت می‌دهد.
    /// </summary>
    /// <param name="id">شناسه شی مورد نیاز</param>
    /// <returns>نمونه ساخته شده از شی</returns>
    TView Get(TId id);
    Task<TView> GetAsync(TId id);

    TView Get(Guid Guid);
    Task<TView> GetAsync(Guid Guid);
    #endregion

    #region GetList
    TView Get();
    Task<IEnumerable<TView>> GetAsync();

    #endregion

    #region Graph
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TView GetGraph(TId id);

    /// <summary>
    /// /
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TView> GetGraphAsync(TId id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Guid"></param>
    /// <returns></returns>
    TView GetGraph(Guid Guid);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Guid"></param>
    /// <returns></returns>
    Task<TView> GetGraphAsync(Guid Guid);
    #endregion

    bool Exists(Expression<Func<TDTO, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TDTO, bool>> expression);
}
