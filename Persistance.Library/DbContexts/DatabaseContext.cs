using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.EntityConfigurations.SEC;
using System.Reflection;

namespace Persistance.Library.DbContexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PictureLocation> PictureLocations { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SEC
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRoleConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new PictureLocationConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new PrivilegeConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
