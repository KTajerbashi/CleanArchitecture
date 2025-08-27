using CleanArchitecture.Core.Domain.UseCases.Store.Entities;
using CleanArchitecture.Core.Domain.ValueObjects;
using CleanArchitecture.Infra.SqlServer.Data.Conversions;
using CleanArchitecture.Infra.SqlServer.Data.Interceptors;

namespace CleanArchitecture.Infra.SqlServer.Data;

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddAuditableShadowProperties<long>();
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }

    #region Store
    public virtual DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public virtual DbSet<CartEntity> Carts => Set<CartEntity>();
    public virtual DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    public virtual DbSet<ProductCartEntity> ProductCarts => Set<ProductCartEntity>();
    public virtual DbSet<ProductCommentEntity> ProductComments => Set<ProductCommentEntity>();
    public virtual DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
    public virtual DbSet<ProductEntity> Products => Set<ProductEntity>();
    #endregion

    //public virtual DbSet<AppUserEntity> AppUserEntities => Set<AppUserEntity>();
    //public virtual DbSet<AppUserClaimEntity> AppUserClaimEntities => Set<AppUserClaimEntity>();
    //public virtual DbSet<AppUserLoginEntity> AppUserLoginEntities => Set<AppUserLoginEntity>();
    //public virtual DbSet<AppUserRoleEntity> AppUserRoleEntities => Set<AppUserRoleEntity>();
    //public virtual DbSet<AppUserTokenEntity> AppUserTokenEntities => Set<AppUserTokenEntity>();
    //public virtual DbSet<AppRoleEntity> AppRoleEntities => Set<AppRoleEntity>();
    //public virtual DbSet<AppRoleClaimEntity> AppRoleClaimEntities => Set<AppRoleClaimEntity>();

    //public virtual DbSet<CategoryEntity> CategoryEntities => Set<CategoryEntity>();
    //public virtual DbSet<ProductEntity> ProductEntities => Set<ProductEntity>();
    //public virtual DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
}