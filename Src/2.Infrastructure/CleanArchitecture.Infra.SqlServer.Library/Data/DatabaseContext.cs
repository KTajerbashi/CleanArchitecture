using CleanArchitecture.Core.Domain.Library.Common;
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;
using CleanArchitecture.Core.Domain.Library.ValueObjects;
using CleanArchitecture.Infra.SqlServer.Library.Data.Conversions;
using System.Reflection;

namespace CleanArchitecture.Infra.SqlServer.Library.Data;

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
        configurationBuilder.Properties<EntityId>().HaveConversion<EntityIdConversion>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public virtual DbSet<CategoryEntity> CategoryEntities => Set<CategoryEntity>();
    public virtual DbSet<ProductEntity> ProductEntities => Set<ProductEntity>();
    public virtual DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
}