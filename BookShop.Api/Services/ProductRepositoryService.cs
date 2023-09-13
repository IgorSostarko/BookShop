using BookShop.Api.Data;
using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Services
{
    public class ProductRepositoryService:IProductRepositoryService
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepositoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = _appDbContext.Products.Include((p)=>p.Category).ToList();
            return Task.FromResult<IEnumerable<Product>>(products);
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _appDbContext.Products.Include((p)=>p.Category).SingleOrDefaultAsync(c => c.Id == id);
            return product;
        }
        public async Task<Product> InsertProduct(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product productToUpdate, Product product)
        {

            productToUpdate.Name = product.Name;
            productToUpdate.Publisher = product.Publisher;
            productToUpdate.PublishingYear= product.PublishingYear;
            productToUpdate.Author = product.Author;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.QuantityInStock= product.QuantityInStock;
            productToUpdate.Price= product.Price;
            productToUpdate.Image=product.Image;
            _appDbContext.Products.Update(productToUpdate);
            await _appDbContext.SaveChangesAsync();
            return productToUpdate;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> ValidateName(string name)
        {
            return await _appDbContext.Products.Where(a => a.Name == name).AnyAsync();
        }

        public Task<IEnumerable<Product>> GetProductsOfCategoryAsync(int categoryId)
        {
            var products = _appDbContext.Products.Where((p)=>p.CategoryId==categoryId).Include((p) => p.Category).ToList();
            return Task.FromResult<IEnumerable<Product>>(products);
        }
    }
}
