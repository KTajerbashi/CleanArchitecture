using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Entities.SEC
{
    [Table("Privileges",Schema ="SEC")]
    [Description("این جدول اطلاعات سطح دسترسی برای نقش ها را نگهداری میکند")]
    public class Privilege : BaseEntity
    {
        [Description("خواندن")]
        public bool Read { get; set; }
        [Description("نوشتن")]
        public bool Write { get; set; }
        [Description("حذف")]
        public bool Delete { get; set; }
        [Description("ویرایش")]
        public bool Update { get; set; }

        [ForeignKey("Role")]
        public long RoleID { get; set; }
        public Role Role { get; set; }
    }
}
