using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DB_Context:DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> Options) : base(Options) { }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }
}
