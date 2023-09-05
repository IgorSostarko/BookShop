using BookShop.Api.Data;
using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BookShop.Api.Services
{
    public class CategoryRepositoryService : ICategoryRepositoryService
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepositoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories=await _appDbContext.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category=await _appDbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }
        public async Task<IEnumerable<int>> ReturnIds()
        {
            var ids=await _appDbContext.Categories.Select(a=>a.Id).ToListAsync();
            return ids;
        }
    }
}
