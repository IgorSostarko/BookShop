using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BookShop.Web.Components.Category;

public partial class AddCategoryForm
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
    public Models.Category category { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

    }
    async Task Submit(Models.Category category)
    {

        var isCreated = await CategoryService.AddCategory(category);
        if (isCreated)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success!", "Succesfuly added to database.");
            NavigationManager.NavigateTo("/categories");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error!", "Could not add to database.");
        }

    }

    void InvalidSubmit() => NotificationService.Notify(NotificationSeverity.Error, "Error!", "Invalid data.");

}
