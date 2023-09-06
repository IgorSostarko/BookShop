using BookShop.Models;

namespace BookShop.Api.Interfaces
{
    public interface ICategoryRepositoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> InsertCategory(Category category);
        Task<Category> UpdateCategoryAsync(Category categoryToUpdate, Category category);
        Task<Category> DeleteCategory(Category category);
    }
}
