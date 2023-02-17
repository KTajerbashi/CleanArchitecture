using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String? Slug { get; set; }
        public String? Title { get; set; }
        public String? MetaTag { get; set; }
        public String? MetaDescription { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}
