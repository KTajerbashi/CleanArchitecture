using CleanArchitecture.Domain.Library.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Library.DataContext
{
    public class DBContextApplication : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region SEC
            builder.Entity<User>().ToTable("Users", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Role>().ToTable("Roles", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<RoleClaim>().ToTable("RoleClaims", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserClaim>().ToTable("UserClaims", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserLogin>().ToTable("UserLogins", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            builder.Entity<UserRole>().ToTable("UserRoles", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(x => new { x.ID, x.UserId, x.RoleId });
            builder.Entity<UserToken>().ToTable("UserTokens", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<User>().HasIndex(x => x.NationalCode).IsUnique();
            #endregion

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
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
