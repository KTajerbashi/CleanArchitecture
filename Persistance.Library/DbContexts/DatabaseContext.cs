using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Library.DbContexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  Seed Data
            SeedData(modelBuilder);

            //  User Data
            UserConfig(modelBuilder);

            //  Apply Relational
            ApplyRelationalOrder(modelBuilder);

            // Query Filter
            ApplyQueryFilter(modelBuilder);

        }
        public void SeedData(ModelBuilder modelBuilder)
        {
            //  Role
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Title = nameof(UserRolesSeed.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Title = nameof(UserRolesSeed.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Title = nameof(UserRolesSeed.Customer) });

        }
        // Order To User And Order to Request Pay Relation

        public void ApplyRelationalOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
               .HasOne(p => p.User)
               .WithMany(p => p.Orders)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public void UserConfig(ModelBuilder modelBuilder)
        {
            //  User
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsActive && !u.IsDeleted);
        }

        public void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserRole>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsDeleted);
        }

    }
}
