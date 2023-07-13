using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("ProductFeatures", Schema = "GEN")]
    public class ProductFeatures : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
