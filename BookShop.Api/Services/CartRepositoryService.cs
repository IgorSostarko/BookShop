using BookShop.Api.Data;
using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Services
{
    public class CartRepositoryService : ICartRepositoryService
    {
        private readonly AppDbContext _appDbContext;
        public CartRepositoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CartExists(string id)
        {
            var cart= await _appDbContext.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (cart == default) {
                await _appDbContext.Carts.AddAsync(new Cart() { Id = id });
                await _appDbContext.SaveChangesAsync();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
