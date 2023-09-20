using Azure;
using BookShop.Models;
using BookShop.Web.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace BookShop.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddToCart(CartProductConnection connection)
        {
            var check = await _httpClient.PostAsJsonAsync($"api/carts", connection);
            return check.IsSuccessStatusCode;
        }

        public async Task<bool> SetUpName(string name)
        {
            var check = await _httpClient.GetFromJsonAsync<bool>($"api/carts/create/{name}");
            return check;
        }
        public async Task<List<CartProductConnection>> GetUserCart(string name)
        {
            var check = await _httpClient.PostAsJsonAsync($"api/carts/get", name);
            var items=check.Content.ReadFromJsonAsync<List<CartProductConnection>>();
            return items.Result;
        }
    }
}
