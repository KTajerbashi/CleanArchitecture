using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.SqlServer.Library.Data;

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }
}