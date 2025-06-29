namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Products", Schema = "Store")]
public class ProductEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    public Description Description { get; set; }
    #endregion

    #region Relations
    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }
    
    public virtual List<ProductDetailEntity> ProductDetails { get; set; }
    #endregion

    #region Constructor
    private ProductEntity() { }
    #endregion

    #region Methods
    #endregion

}
