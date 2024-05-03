using Design.Pattern.Library.Composite.Categories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Design.Pattern.Library.Context
{
    //public class DatabaseContext : IdentityDbContext
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        public DbSet<CategoryComponent> CategoryComponents { get; set; }
        private DbSet<CategoryComposite> CategoryComposites { get; set; }
        private DbSet<CategoryItemLeaf> CategoryItemLeaves { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
Data Source = TAJERBASHI;
Initial Catalog = Console_Database;
User ID = sa; 
Password = 123123;
TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
