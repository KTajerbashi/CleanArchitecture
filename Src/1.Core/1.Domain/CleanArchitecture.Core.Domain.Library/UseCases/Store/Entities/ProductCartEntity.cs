namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("ProductCarts", Schema = "Store")]
public class ProductCartEntity : BaseAuditableEntity
{
    #region Properties

    #endregion

    #region Relations
    [ForeignKey(nameof(Cart))]
    public long CartId { get; set; }
    public virtual CartEntity Cart { get; set; }

    [ForeignKey(nameof(Product))]
    public long ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
    #endregion

    #region Constructor
    private ProductCartEntity() { }
    #endregion

    #region Methods
    public static ProductCartEntity CreateInstance(long cartId, long productId)
    {
        return new ProductCartEntity() { ProductId = productId, CartId = cartId };
    }
    #endregion

}
