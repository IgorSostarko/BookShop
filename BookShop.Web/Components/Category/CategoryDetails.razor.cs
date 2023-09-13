using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Globalization;

namespace BookShop.Web.Components.Category;

public partial class CategoryDetails
{
    [Inject]
    public IProductService? ProductService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    [Inject]
    public NotificationService? NotificationService { get; set; }
    [Inject]
    public DialogService? DialogService { get; set; }
    [Inject]
    public ICategoryService? CategoryService { get; set; }
    [Parameter]
    public int id { get; set; }
    CultureInfo hr = new CultureInfo("fr-FR");
    public Models.Category? category;
    public List<Models.Product>? products;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        category = await CategoryService.GetCategory(id);
        products = await ProductService.GetProductsByCategory(id);
    }
    void Cancel() => NavigationManager.NavigateTo("/categories");
    public void GetDetails(int id)
    {
        NavigationManager.NavigateTo($"/product/{id}/category");
    }
}
