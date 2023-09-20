using BookShop.Models;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProductConnection> CartProducts { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartProductConnection>().HasKey(a => new { a.ProductId, a.CartId });
            modelBuilder.Entity<Category>().HasData(DataInitializer.ReturnCategoryData());
            modelBuilder.Entity<Product>().HasData(DataInitializer.ReturnProductData());
        }
    }
}
