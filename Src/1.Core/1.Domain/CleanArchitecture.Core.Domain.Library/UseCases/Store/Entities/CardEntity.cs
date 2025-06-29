
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Cards", Schema = "Store")]
public class CardEntity : BaseAuditableEntity
{
    #region Properties
    public Title Title { get; set; }
    #endregion

    #region Relations
    public virtual List<ProductEntity> ProductEntities { get; set; }
    #endregion

    #region Constructor
    private CardEntity() { }
    #endregion

    #region Methods
    #endregion

}
