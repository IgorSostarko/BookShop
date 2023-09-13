using BookShop.Models;

namespace BookShop.Web.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>?> GetProducts();
        Task<List<Product>?> GetProductsByCategory(int categoryId);
        Task<Product?> GetProduct(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task DeleteProduct(Product product);
        public bool ValidateName(string name);
    }
}
