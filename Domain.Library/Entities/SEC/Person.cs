using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.SEC
{
    [Table("People", Schema = "SEC")]
    public class Person : BaseEntity
    {
        [Description("نام")]
        public string Name { get; set; }
        [Description("فامیل")]
        public string Family { get; set; }
        [Description("ایمیل")]
        public string Email { get; set; }
        [Description("رمز")]
        public string Password { get; set; }
        [Description("نام کاربری")]
        public string Username { get; set; }
        [Description("تلفن")]
        public string Phone { get; set; }
        [Description("تعداد عکس های برای این رکورد")]
        public ICollection<Picture> Pictures { get; set; }
        [Description("تعداد نقش های که میتواند داشته باشد")]
        public ICollection<PersonRole> PersonRoles { get; set; }

    }
}
