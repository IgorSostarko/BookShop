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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(DataInitializer.ReturnCategoryData());
            modelBuilder.Entity<Product>().HasData(DataInitializer.ReturnProductData());
        }
    }
}
