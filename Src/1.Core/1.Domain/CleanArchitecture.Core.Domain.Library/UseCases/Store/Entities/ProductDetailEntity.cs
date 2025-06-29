
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

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
    #endregion



}