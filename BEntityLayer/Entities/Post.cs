using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntityLayer.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }
        public int Visit { get; set; }
        public string Slug { get; set; }


        public ICollection<Comments> Comments { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
