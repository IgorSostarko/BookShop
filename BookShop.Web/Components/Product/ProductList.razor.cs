using System.Net.NetworkInformation;

using BookShop.Models;
using BookShop.Web.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace BookShop.Web.Components.Product;

public partial class ProductList
{
    [Inject]
    public IProductService? ProductService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    [Inject]
    public NotificationService? NotificationService { get; set; }
    [Inject]
    public DialogService? DialogService { get; set; }
    CultureInfo hr = new CultureInfo("fr-FR");
    public RadzenDataGrid<Models.Product> grid;
    public IList<Models.Product>? selected;
    public List<Models.Product>? Products { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Products = await ProductService.GetProducts();
    }
    public void Details()
    {
        if (selected is not null)
        {
            NavigationManager.NavigateTo($"product/{selected[0].Id}");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Product");
        }
    }
    public void AddProduct()
    {
        NavigationManager.NavigateTo($"product/add");
    }
    public void UpdateProduct()
    {
        if (selected is not null)
        {
            NavigationManager.NavigateTo($"product/edit/{selected.First().Id}");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Product");
        }
    }

    public async Task DeleteProduct()
    {
        if (selected is not null)
        {
            var confirmDelete = await DialogService.Confirm($"Delete item with id {selected[0].Id}?", "Confirm", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });
            if (confirmDelete.GetValueOrDefault())
            {
                await ProductService.DeleteProduct(selected.First());
                NavigationManager.NavigateTo("/products", true);
            }
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Product");
        }
    }
}
