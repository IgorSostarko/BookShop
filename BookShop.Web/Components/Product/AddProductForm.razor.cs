using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;
namespace BookShop.Web.Components.Product;

public partial class AddProductForm:ComponentBase
{
    [Inject]
    public IProductService? ProductService { get; set; }
    [Inject]
    public NotificationService? NotificationService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    [Inject]
    public ICategoryService? CategoryService { get; set; }
    public Models.Product Product { get; set; } = new();
    public List<Models.Category>? Categories;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Categories = await CategoryService.GetCategories();

    }
    async Task Submit(Models.Product product)
    {

        var isCreated = await ProductService.AddProduct(product);
        if (isCreated)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success!", "Succesfuly added to database.");
            NavigationManager.NavigateTo("/products");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error!", "Could not add to database.");
        }

    }
    void InvalidSubmit() => NotificationService.Notify(NotificationSeverity.Error, "Error!", "Invalid data.");
}
