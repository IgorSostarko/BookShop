using BookShop.Models;

namespace BookShop.Web.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>?> GetCategories();
        Task<Category?> GetCategory(int id);
        Task AddCategory(Category category);
    }
}
