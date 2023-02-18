using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public bool IsDelete { get; set; }

    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
