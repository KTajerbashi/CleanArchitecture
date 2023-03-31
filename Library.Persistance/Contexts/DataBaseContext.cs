using Library.Application;
using Library.Common;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().ToTable("Role").HasData(new Role { Id = 1, Name = nameof(UserRolesValue.Admin) });
            modelBuilder.Entity<Role>().ToTable("Role").HasData(new Role { Id = 2, Name = nameof(UserRolesValue.Operator) });
            modelBuilder.Entity<Role>().ToTable("Role").HasData(new Role { Id = 3, Name = nameof(UserRolesValue.Customer) });
        }

    }
}
