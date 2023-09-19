﻿using BookShop.Web.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using System.Globalization;

namespace BookShop.Web.Components.Category;

public partial class CategoryDetails:ComponentBase
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
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }
    public AuthenticationState? user;
    [Parameter]
    public int id { get; set; }
    CultureInfo hr = new CultureInfo("fr-FR");
    public Models.Category? category;
    public List<Models.Product>? products;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        user = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        category = await CategoryService.GetCategory(id);
        products = await ProductService.GetProductsByCategory(id);
    }
    void Cancel() => NavigationManager.NavigateTo("/categories");
    public void GetDetails(int id)
    {
        NavigationManager.NavigateTo($"/product/{id}/category");
    }
    public async void AddToCart(int id)
    {
        if (!user.User.Identity.IsAuthenticated)
        {
            var login = await DialogService.Alert($"You have to be loged in to add to cart!", "Not loged in!", new AlertOptions() { OkButtonText = "Log in" });
            if (login ?? false)
            {
                NavigationManager.NavigateTo("/login", true);
            }
        }
    }
}
