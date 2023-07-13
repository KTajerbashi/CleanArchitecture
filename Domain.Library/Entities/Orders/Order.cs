using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Orders", Schema = "GEN")]
    public class Order : BaseEntity
    {

        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual RequestPay RequestPay { get; set; }
        public long RequestPayId { get; set; }

        public OrderState OrderState { get; set; }

        public string Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
