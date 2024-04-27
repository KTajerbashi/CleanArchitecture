﻿using CleanArchitecture.Domain.Library.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Library.DataContext
{
    public class DBContextApplication : IdentityDbContext<UserEntity, RoleEntity, long, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Security
            builder.Entity<UserEntity>().ToTable("Users", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<RoleEntity>().ToTable("Roles", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserClaimEntity>().ToTable("UserClaims", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserLoginEntity>().ToTable("UserLogins", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            builder.Entity<UserRoleEntity>().ToTable("UserRoles", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(x => new { x.ID, x.UserId, x.RoleId });
            builder.Entity<UserTokenEntity>().ToTable("UserTokens", "Security").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserEntity>().HasIndex(x => x.NationalCode).IsUnique();
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
