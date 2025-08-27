using CleanArchitecture.Core.Domain.Common;
using CleanArchitecture.Core.Domain.ValueObjects;

namespace CleanArchitecture.Core.Domain.UseCases.Store.Entities;

[Table("Categories", Schema = "Store")]
public class CategoryEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    #endregion

    #region Relations
    public virtual List<ProductEntity> ProductEntities { get; set; } = new();
    #endregion

    #region Constructor
    private CategoryEntity() { }
    #endregion

    #region Methods
    public static CategoryEntity CreateInstance(string title)
    {
        return new CategoryEntity() { Title = title };
    }
    public void AddProduct(ProductEntity entity) => ProductEntities.Add(entity);
    #endregion

}
