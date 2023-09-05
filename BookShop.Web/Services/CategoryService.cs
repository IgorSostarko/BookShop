using BookShop.Models;
using BookShop.Web.Interfaces;

namespace BookShop.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>?> GetCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>("api/categories");
            return categories;
        }

        public async Task<Category?> GetCategory(int id)
        {
            var category = await _httpClient.GetFromJsonAsync<Category>($"api/categories/{id}");
            return category;
        }
        public async Task AddCategory(Category category)
        {
            await _httpClient.PostAsJsonAsync("api/categories", category);
        }
    }
}
