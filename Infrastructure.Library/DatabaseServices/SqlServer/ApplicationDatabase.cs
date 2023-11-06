using Application.Library.DatabaseServices;
using Domain.Library.Entities.RPT;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.EF.DatabaseContext.SqlServerDb;

namespace Infrastructure.Library.DatabaseServices.SqlServer
{
    public class ApplicationDatabase : ApplicationDatabaseBase, IDatabaseRepository
    {
        public ApplicationDatabase(DbContextOptions option) : base(option)
        {
        }

        public DbSet<UserReport> UserReports { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        #region CNT
        #endregion
        #region LOG
        #endregion
        #region PRD
        #endregion
        #region RPT
        #endregion
        #region SEC
        #endregion

        protected void Creating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void Configuration(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
