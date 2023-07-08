using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Library.DbContexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Title = nameof(UserRolesSeed.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Title = nameof(UserRolesSeed.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Title = nameof(UserRolesSeed.Customer) });


            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsActive && !u.IsDeleted);

        }



    }
}
