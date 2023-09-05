using BookShop.Models;

namespace BookShop.Api.Interfaces
{
    public interface ICategoryRepositoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> InsertCategory(Category category);
    }
}
