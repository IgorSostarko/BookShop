using System.Net.NetworkInformation;

using BookShop.Models;
using BookShop.Web.Interfaces;
using BookShop.Web.Services;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Radzen;


namespace BookShop.Web.Components.Product;

public partial class UpdateProduct
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
    public Models.Product product { get; set; } = new();
    public List<Models.Category>? Categories;
    string name = "";
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        product = await ProductService.GetProduct(id);
        name = product.Name;
        Categories = await CategoryService.GetCategories();
    }
    async Task Submit(Models.Product product)
    {
        var isSuccess = await ProductService.UpdateProduct(id, product);
        if (isSuccess)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success!", "Updated succesfuly.");
            NavigationManager.NavigateTo("/products");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error!", "Could not update.");
        }

    }

    void InvalidSubmit() => NotificationService.Notify(NotificationSeverity.Error, "Error!", "Invalid data.");
}
