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
        public async Task<Category> InsertCategory(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category categoryToUpdate, Category category)
        {
            
            categoryToUpdate.Name= category.Name;
            categoryToUpdate.DisplayOrder = category.DisplayOrder;
            _appDbContext.Categories.Update(categoryToUpdate);
            await _appDbContext.SaveChangesAsync();
            return categoryToUpdate;
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }
    }
}
