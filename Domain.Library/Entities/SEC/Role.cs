using Domain.Library.BasesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Entities.SEC
{
    [Table("Roles",Schema ="SEC")]
    [Description("این جدول نقش های های کاربری را نگهداری میکند")]
    public class Role: BaseEntity
    {
        [Description("عنوان")]
        public string Title { get; set; }
        [Description("توضیحات")]
        public string Description { get; set; }

        [Description("تعداد نقش های که میتواند داشته باشد")]
        public ICollection<UserRole> UserRoles { get; set; }

        [Description("دسترسی")]
        public Privilege Privilege { get; set; }
    }
}
