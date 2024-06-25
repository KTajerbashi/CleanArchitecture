using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;

public abstract class BaseCommandDatabaseContext : BaseDatabaseContext
{
    public BaseCommandDatabaseContext(DbContextOptions options):base(options)
    {
        
    }
    protected BaseCommandDatabaseContext()
    {
        
    }
}
