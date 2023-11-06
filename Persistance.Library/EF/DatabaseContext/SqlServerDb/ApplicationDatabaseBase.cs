using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.EF.Identity;

namespace Persistance.Library.EF.DatabaseContext.SqlServerDb
{
    public class ApplicationDatabaseBase : IdentityDbContext<AppUser>
    {
        public ApplicationDatabaseBase(DbContextOptions option) : base(option)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
