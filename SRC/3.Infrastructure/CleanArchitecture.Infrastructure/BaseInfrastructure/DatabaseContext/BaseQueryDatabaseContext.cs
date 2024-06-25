using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;

public abstract class BaseQueryDatabaseContext : BaseDatabaseContext
{

    protected BaseQueryDatabaseContext(DbContextOptions options):base(options)
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int SaveChanges()
    {
        throw new NotImplementedException();
    }
   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotImplementedException();
    }

}