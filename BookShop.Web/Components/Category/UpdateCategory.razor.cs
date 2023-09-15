using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;


namespace BookShop.Web.Components.Category;

public partial class UpdateCategory:ComponentBase
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
    public Models.Category Category { get; set; } = new();
    public Models.Category category1;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Category = await CategoryService.GetCategory(id);
        category1 = new() { Id = Category.Id, DisplayOrder = Category.DisplayOrder, Name = Category.Name };
    }
    async Task Submit(Models.Category category)
    {
        var isSuccess = await CategoryService.UpdateCategory(id, category);
        if (isSuccess)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success!", "Updated succesfuly.");
            NavigationManager.NavigateTo("/categories");
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error!", "Could not update.");
        }

    }
    void InvalidSubmit() => NotificationService.Notify(NotificationSeverity.Error, "Error!", "Invalid data.");
}
