namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;


[Table("Products", Schema = "Store")]
public class ProductEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    public Description Description { get; set; }
    #endregion

    #region Relations
    public virtual List<ProductDetailEntity> ProductDetails { get; set; } = new();
    public virtual List<ProductCartEntity> ProductCarts { get; set; } = new();
    public virtual List<ProductCommentEntity> ProductComments { get; set; } = new();

    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public virtual CategoryEntity  Category { get; set; }
    #endregion

    #region Constructor
    private ProductEntity() { }
    #endregion

    #region Methods
    public static ProductEntity CreateInstance(Title title, Description description)
    {
        return new ProductEntity() { Title = title, Description = description };
    }
    public void AddDetail(ProductDetailEntity entity) => ProductDetails.Add(entity);
    public void AddComment(ProductCommentEntity entity) => ProductComments.Add(entity);
    #endregion

}
