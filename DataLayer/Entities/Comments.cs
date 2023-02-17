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
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="متن را وارد کنید")]
        public String? Text { get; set; }

        [ForeignKey("PostId")]
        public Post? Post { get; set; }
    }
}
