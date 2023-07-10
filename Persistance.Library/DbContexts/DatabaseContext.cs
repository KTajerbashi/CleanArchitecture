using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  Seed Data
            SeedData(modelBuilder);

            //  User Data
            UserConfig(modelBuilder);

            // Query Filter
            ApplyQueryFilter(modelBuilder);

        }
        public void SeedData(ModelBuilder modelBuilder)
        {
            //  Role
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Title = nameof(UserRolesSeed.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Title = nameof(UserRolesSeed.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Title = nameof(UserRolesSeed.Customer) });

        }
        public void UserConfig(ModelBuilder modelBuilder)
        {
            //  User
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsActive && !u.IsDeleted);
        }

        public void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserRole>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
        }

    }
}
