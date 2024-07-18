namespace CleanArchitecture.Application.BaseApplication.Repositories;

public interface IBaseQueryRepository<TEntity,TId>
{
    Task<TEntity> GetAsync(TId id);
    Task<IEnumerable<TEntity>> GetAsync();

}
