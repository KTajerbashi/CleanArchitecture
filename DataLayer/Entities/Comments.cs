using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Comments
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public String? Text { get; set; }
        public Post? Post { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


    }
}
