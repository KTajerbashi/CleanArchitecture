using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("UserRoles", Schema = "SEC")]
    [Description("این جدول نقش های افراد ذخیره میکند")]
    public class UserRole : BaseEntity
    {
        [ForeignKey("User")]
        public long UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public long RoleID { get; set; }
        public Role Role { get; set; }

    }


}
