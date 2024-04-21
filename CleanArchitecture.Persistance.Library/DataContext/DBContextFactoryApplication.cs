using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitecture.Persistence.Library.DataContext
{
    public class DBContextFactoryApplication : IDesignTimeDbContextFactory<DBContextApplication>
    {
        public DBContextApplication CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContextApplication>();
            return new DBContextApplication(optionsBuilder.Options);
        }
    }
}
