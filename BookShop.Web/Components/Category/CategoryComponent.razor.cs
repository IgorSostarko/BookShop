using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BookShop.Web.Components.Category;

public partial class CategoryComponent
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
    public Models.Category Model { get; set; } = new();
    [Parameter]
    public Models.Category? OldData { get; set; }
    [Parameter]
    public string? Text { get; set; }
    void Cancel() => NavigationManager.NavigateTo("/categories", true);
    bool NameValidator(string name)
    {
        if (OldData is not null)
        {
            if (name == OldData.Name) return true;
            var checker = CategoryService.ValidateName(name);
            return !checker;
        }
        else
        {
            var checker = CategoryService.ValidateName(name);
            return !checker;
        }

    }
    bool DisplayOrderValidator(int displayOrder)
    {
        if (OldData is not null)
        {
            if (displayOrder == OldData.DisplayOrder) return true;
            var checker = CategoryService.ValidateDisplayOrder(displayOrder);
            return !checker;
        }
        else
        {
            var checker = CategoryService.ValidateDisplayOrder(displayOrder);
            return !checker;
        }

    }
}
