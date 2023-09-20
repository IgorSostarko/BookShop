using BookShop.Models;

namespace BookShop.Api.Interfaces
{
    public interface ICartRepositoryService
    {
        Task<bool> CartExists(string id);
        public Task<CartProductConnection> AddToCart(CartProductConnection connection);
        public Task<List<CartProductConnection>> GetItemsOfCart(string user);
    }
}
