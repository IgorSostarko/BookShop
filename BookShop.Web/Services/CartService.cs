using BookShop.Web.Interfaces;

namespace BookShop.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> SetUpName(string name)
        {
            var check = await _httpClient.GetFromJsonAsync<bool>($"api/carts/create/{name}");
            return check;
        }
    }
}
