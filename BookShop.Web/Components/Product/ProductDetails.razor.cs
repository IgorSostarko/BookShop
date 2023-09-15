using Microsoft.AspNetCore.Components;
using System.Globalization;
using BookShop.Web.Interfaces;


namespace BookShop.Web.Components.Product;

public partial class ProductDetails:ComponentBase
{
    [Inject]
    public IProductService? ProductService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    CultureInfo hr = new CultureInfo("fr-FR");
    [Parameter]
    public int id { get; set; }
    [Parameter]
    public string? path { get; set; }
    public List<Models.Product>? Products;
    public Models.Product product;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        product = await ProductService.GetProduct(id);
        Products = new List<Models.Product>() { product };
    }
    void Cancel()
    {
        if (path is null)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            NavigationManager.NavigateTo($"/{path}/{product.CategoryId}");
        }
    }
}
