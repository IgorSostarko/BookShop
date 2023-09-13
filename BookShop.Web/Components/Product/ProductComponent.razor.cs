using System.Net.NetworkInformation;

using BookShop.Models;
using BookShop.Web.Interfaces;
using BookShop.Web.Services;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BookShop.Web.Components.Product;

public partial class ProductComponent
{
    [Inject]
    public IProductService? ProductService { get; set; }
    [Inject]
    public NotificationService? NotificationService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    [Inject]
    public ICategoryService? CategoryService { get;set; }
    CultureInfo hr = new CultureInfo("fr-FR");
    string fileName;
    long? fileSize;
    [Parameter]
    public string? Name { get; set; }
    [Parameter]
    public Models.Product Model { get; set; } = new();
    [Parameter]
    public List<Models.Category>? Categories { get; set; }
    [Parameter]
    public string? Text { get; set; }
    void Cancel() => NavigationManager.NavigateTo("/products", true);

    void OnChange(string value, string name)
    {
        NotificationService.Notify(NotificationSeverity.Success, "Success!", "Succesfuly uploaded.");
    }

    void OnError(UploadErrorEventArgs args, string name)
    {
        NotificationService.Notify(NotificationSeverity.Success, "Error!", "Error with uploading.");
    }
    bool NameValidator(string name_)
    {
        if (Name != "")
        {
            if (name_ == Name) return true;
            var checker = ProductService.ValidateName(name_);
            return !checker;
        }
        else
        {
            var checker = ProductService.ValidateName(name_);
            return !checker;
        }
    }
}
