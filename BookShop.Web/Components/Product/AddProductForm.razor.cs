using Radzen;
using System.Globalization;
using System.Net.NetworkInformation;

using BookShop.Models;
using BookShop.Web.Interfaces;
using BookShop.Web.Services;
using System.Globalization;

namespace BookShop.Web.Components.Product
{
    public partial class AddProductForm
    {
        CultureInfo hr = new CultureInfo("fr-FR");
        string fileName;
        long? fileSize;
        public Models.Product product { get; set; } = new();
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
        bool NameValidator(string name)
        {
            var checker = ProductService.ValidateName(name);
            return !checker;
        }
        void InvalidSubmit() => NotificationService.Notify(NotificationSeverity.Error, "Error!", "Invalid data.");
        void Cancel() => NavigationManager.NavigateTo("/products");
        void OnChange(string value, string name)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success!", "Succesfuly uploaded.");
        }

        void OnError(UploadErrorEventArgs args, string name)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error!", "Error with uploading.");
        }
    }
}
