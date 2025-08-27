using CleanArchitecture.Core.Domain.Common;
using CleanArchitecture.Core.Domain.ValueObjects;

namespace CleanArchitecture.Core.Domain.UseCases.Store.Entities;

[Table("ProductDetails", Schema = "Store")]
public class ProductDetailEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    public string Value { get; set; }
    #endregion

    #region Relations
    [ForeignKey(nameof(Product))]
    public long ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
    #endregion

    #region Constructor
    private ProductDetailEntity() { }
    #endregion

    #region Methods
    public static ProductDetailEntity CreateInstance(Title title,string value)
    {
        return new ProductDetailEntity() { Title = title, Value = value };
    }
    #endregion



}