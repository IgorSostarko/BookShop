using BookShop.Models;
using BookShop.Web.Interfaces;

namespace BookShop.Web.Services;

public class ProductService:IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>?> GetProducts(string query="")
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>($"api/products{query}");
        return products;
    }

    public async Task<Product?> GetProduct(int id)
    {
        var product = await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        return product;
    }
    public async Task<bool> AddProduct(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProduct(int id, Product product)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", product);

        return response.IsSuccessStatusCode;
    }

    public async Task DeleteProduct(Product product)
    {
        await _httpClient.DeleteFromJsonAsync($"api/products/{product.Id}", typeof(Product));
    }
    public bool ValidateName(string name)
    {
        if (name is null || name=="")
        {
            return false;
        }
        var result = _httpClient.GetFromJsonAsync<bool>($"api/products/validate-name?name={name}");
        return result.Result;
    }

    public async Task<List<Product>?> GetProductsByCategory(int categoryId)
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>($"api/products?categoryId={categoryId}");
        return products;
    }
}
