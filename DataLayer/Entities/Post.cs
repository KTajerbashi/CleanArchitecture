using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }
        public int Visit { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


        public ICollection<Comments> Comments { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
