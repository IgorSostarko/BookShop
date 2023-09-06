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
        public async Task<bool> AddCategory(Category category)
        {
            var response= await _httpClient.PostAsJsonAsync("api/categories", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            var response=await _httpClient.PutAsJsonAsync($"api/categories/{id}", category);

            return response.IsSuccessStatusCode;
        }

        public async Task DeleteCategory(Category category)
        {
            await _httpClient.DeleteFromJsonAsync($"api/categories/{category.Id}", typeof(Category));
        }
    }
}
