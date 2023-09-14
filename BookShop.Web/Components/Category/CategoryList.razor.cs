using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace BookShop.Web.Components.Category;

public partial class CategoryList
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
    public RadzenDataGrid<Models.Category> grid;
    public IList<Models.Category>? selected;
    public List<Models.Category>? Categories { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Categories = await CategoryService.GetCategories();
    }
    public void Details()
    {
        if (selected is not null)
        {
            NavigationManager.NavigateTo($"category/{selected[0].Id}");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Category");
        }
    }
    public void AddCategory()
    {
        NavigationManager.NavigateTo($"category/add");
    }
    public void UpdateCategory()
    {
        if (selected is not null)
        {
            NavigationManager.NavigateTo($"category/edit/{selected.First().Id}");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Category");
        }
    }

    public async Task DeleteCategory()
    {
        if (selected is not null)
        {
            
            var confirmDelete = await DialogService.Confirm($"Delete item with id {selected[0].Id}?", "Confirm", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });
            if (confirmDelete.GetValueOrDefault())
            {
                var products = await ProductService.GetProductsByCategory(selected[0].Id);
                if (products.Count > 0)
                {
                    string ids = "";
                    foreach (var product in products)
                    {
                        ids+= product.Id + " ";
                    }
                    DialogService.Alert($"Category has products with ids: \n {ids}", "Error!", new AlertOptions() { OkButtonText = "Ok" });
                }
                else
                {
                    await CategoryService.DeleteCategory(selected.First());
                    NavigationManager.NavigateTo("/categories", true);
                }
                    
            }
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Warning, "Select Category");
        }
    }
}
