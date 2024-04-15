using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF
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
