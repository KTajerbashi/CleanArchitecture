
using CleanArchitecture.Core.Domain.Library.UseCases.Store.Enums;

namespace CleanArchitecture.Core.Domain.Library.UseCases.Store.Entities;

[Table("ProductComments", Schema = "Store")]
public class ProductCommentEntity : BaseAuditableEntity
{
    [ForeignKey(nameof(Customer))]
    public long CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; }

    public Title Title { get; set; }
    public Description Description { get; set; }

    public RateType Rate { get; set; }
}
