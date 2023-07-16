using Application.Library.Interfaces;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.EntityConfigurations;
using System.Reflection;

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
            //  User
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //  Role
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //  UserRole
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //  Category
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());

            //  Product
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //  ProductImages
            modelBuilder.ApplyConfiguration(new ProductImagesConfiguration());

            //  ProductFeatures
            modelBuilder.ApplyConfiguration(new ProductFeaturesConfiguration());

            //  Slider
            modelBuilder.ApplyConfiguration(new SliderConfiguration());

            //  HomePageImages
            modelBuilder.ApplyConfiguration(new HomePageImagesConfiguration());

            //  Cart
            modelBuilder.ApplyConfiguration(new CartConfiguration());

            //  CartItem
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());

            //  RequestPay
            modelBuilder.ApplyConfiguration(new RequestPayConfiguration());

            //  Order
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            //  OrderDetail
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

        }
    }
}
