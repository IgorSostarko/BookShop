using BookShop.Models;

namespace BookShop.Api.Interfaces;

public interface IProductRepositoryService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetProductsOfCategoryAsync(int categoryId);
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> InsertProduct(Product product);
    Task<Product> UpdateProductAsync(Product productToUpdate, Product product);
    Task<Product> DeleteProduct(Product product);
    Task<bool> ValidateName(string name);
}
