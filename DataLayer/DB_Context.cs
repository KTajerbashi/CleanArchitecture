using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataLayer
{
    public class DB_Context:DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> Options) : base(Options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            //
            //modelBuilder.Entity<User>().HasKey(s => s.UserId);

            //modelBuilder.Entity<Comments>().HasKey(s => s.CommentId);

            //modelBuilder.Entity<Post>().HasKey(s => s.PostId);

            //modelBuilder.Entity<Category>().HasKey(s => s.CategoryId);
        }

    }
}
