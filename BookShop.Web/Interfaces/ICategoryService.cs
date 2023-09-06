using BookShop.Models;

namespace BookShop.Web.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>?> GetCategories();
        Task<Category?> GetCategory(int id);
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(int id, Category category);
        Task DeleteCategory(Category category);
    }
}
