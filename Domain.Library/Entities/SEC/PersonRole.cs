using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("PersonRoles", Schema = "SEC")]
    [Description("این جدول نقش های افراد ذخیره میکند")]
    public class PersonRole : BaseEntity
    {
        [ForeignKey("Person")]
        public long PersonID { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Role")]
        public long RoleID { get; set; }
        public Role Role { get; set; }

    }


}
