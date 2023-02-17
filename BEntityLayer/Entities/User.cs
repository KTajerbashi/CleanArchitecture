using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEntityLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }

        public ICollection<Post>? Posts { get; set; } 
        public ICollection<Comments>? Comments { get; set; }
    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
