using BookShop.Models;

namespace BookShop.Api.Interfaces
{
    public interface ICategoryRepositoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
