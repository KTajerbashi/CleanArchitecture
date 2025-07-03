
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Carts", Schema = "Store")]
public class CartEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    #endregion

    #region Relations
    public virtual List<ProductCartEntity> ProductCarts { get; set; } = new();

    [ForeignKey(nameof(Customer))]
    public long CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }
    #endregion

    #region Constructor
    private CartEntity() { }
    #endregion

    #region Methods
    public static CartEntity CreateInstance(Title title)
    {
        return new CartEntity() { Title = title };
    }
    #endregion

}
