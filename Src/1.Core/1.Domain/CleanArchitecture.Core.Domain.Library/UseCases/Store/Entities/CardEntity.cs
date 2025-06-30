
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Cards", Schema = "Store")]
public class CardEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    #endregion

    #region Relations
    public virtual List<ProductCardEntity> ProductCards { get; set; } = new();
    #endregion

    #region Constructor
    private CardEntity() { }
    #endregion

    #region Methods
    public static CardEntity CreateInstance(Title title)
    {
        return new CardEntity() { Title = title };
    }
    #endregion

}
