using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntityLayer.Entities
{
    public class Comments
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Required]
        public String? Text { get; set; }


        public Post? Post { get; set; }
        public User? User { get; set; }
    }
}
