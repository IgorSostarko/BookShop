using BookShop.Web.Interfaces;
using BookShop.Web.Services;
using Radzen;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookShop.Web.Data;
using BookShop.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookShopConnectionString") ?? throw new InvalidOperationException("Connection string 'BookShopConnectionString' not found.");

builder.Services.AddDbContext<BookShopWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BookShopWebUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<BookShopWebContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(o=>
{
    o.MaximumReceiveMessageSize = 10 * 1024*1024;
});
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ProtectedLocalStorage>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7003/");
});
builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7003/");
});
builder.Services.AddHttpClient<ICartService, CartService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7003/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

