using CleanArchitecture.Core.Domain.Common;
using CleanArchitecture.Core.Domain.UseCases.Store.Enums;
using CleanArchitecture.Core.Domain.ValueObjects;

namespace CleanArchitecture.Core.Domain.UseCases.Store.Entities;

[Table("ProductComments", Schema = "Store")]
public class ProductCommentEntity : BaseAuditableEntity
{

    #region Properties
    public Title Title { get; set; }
    public Description Description { get; set; }
    public RateType Rate { get; set; }
    #endregion

    #region Relations
    [ForeignKey(nameof(Customer))]
    public long CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; }

    [ForeignKey(nameof(Product))]
    public long ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
    #endregion

    #region Constructor
    private ProductCommentEntity() { }
    #endregion

    #region Methods
    public static ProductCommentEntity CreateInstance(
        Title title,
        Description description,
        RateType rate
        )
    {
        return new ProductCommentEntity() { Title = title, Description = description, Rate = rate };
    }
    public void SetCustomerId(long id) => CustomerId = id;
    public void SetProductId(long id) => ProductId = id;
    #endregion

}
