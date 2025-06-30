namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("ProductCards", Schema = "Store")]
public class ProductCardEntity : BaseAuditableEntity
{
    #region Properties

    #endregion

    #region Relations
    [ForeignKey(nameof(Card))]
    public long CardId { get; set; }
    public virtual CardEntity Card { get; set; }

    [ForeignKey(nameof(Product))]
    public long ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
    #endregion

    #region Constructor
    private ProductCardEntity() { }
    #endregion

    #region Methods
    public static ProductCardEntity CreateInstance(long cardId, long productId)
    {
        return new ProductCardEntity() { ProductId = productId, CardId = cardId };
    }
    #endregion

}
