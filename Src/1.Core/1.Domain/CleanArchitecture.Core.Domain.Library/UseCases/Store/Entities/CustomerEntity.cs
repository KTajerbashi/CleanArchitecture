
namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("Customers", Schema = "Store")]
public class CustomerEntity : BaseAuditableEntity
{
    #region Properties
    public string Name { get; set; }
    public string Phone { get; set; }
    #endregion

    #region Relations
    public virtual List<CardEntity> Cards { get; set; }
    public virtual List<ProductCommentEntity> ProductComments { get; set; }
    #endregion

    #region Constructor
    private CustomerEntity() { }
    #endregion

    #region Methods
    public static CustomerEntity CreateInstance(string name,string phone)
    {
        return new CustomerEntity() { Name = name, Phone = phone };
    }
    #endregion

}
