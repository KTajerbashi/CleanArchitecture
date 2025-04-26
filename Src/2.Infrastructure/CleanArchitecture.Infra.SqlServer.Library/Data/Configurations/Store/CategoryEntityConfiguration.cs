using CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.SqlServer.Library.Data.Configurations.Store;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}


public class ProductDetailEntityConfiguration : IEntityTypeConfiguration<ProductDetailEntity>
{
    public void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}


public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
