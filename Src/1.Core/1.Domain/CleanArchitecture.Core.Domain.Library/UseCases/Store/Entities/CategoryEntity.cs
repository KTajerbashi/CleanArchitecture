
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Categories", Schema = "Store")]
public class CategoryEntity : BaseAuditableEntity
{
    public Title Title { get; set; }
    public virtual List<ProductEntity> ProductEntities { get; set; }
    public CategoryEntity()
    {
    }
}
[Table("Products", Schema = "Store")]
public class ProductEntity : BaseAuditableEntity
{
    public Title Title { get; set; }
    public Description Description { get; set; }

    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public virtual CategoryEntity Category{ get; set; }

    public virtual List<ProductDetailEntity> ProductDetails { get; set; }
}
[Table("ProductDetails",Schema = "Store")]
public class ProductDetailEntity : BaseAuditableEntity
{
    [ForeignKey(nameof(Product))]
    public long ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }

    public Title Title { get; set; }
    public string Value { get; set; }
}