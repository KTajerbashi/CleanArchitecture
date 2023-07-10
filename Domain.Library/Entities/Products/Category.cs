using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Entities
{
    [Table("Category", Schema = "SEC")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        //  برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Category> SubCategories { get; set; }

    }
}
