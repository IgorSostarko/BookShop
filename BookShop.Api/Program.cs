using BookShop.Api.Data;
using BookShop.Api.Interfaces;
using BookShop.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookShopConnectionString"));
});

builder.Services.AddScoped<ICategoryRepositoryService, CategoryRepositoryService>();
builder.Services.AddScoped<IProductRepositoryService, ProductRepositoryService>();  
builder.Services.AddScoped<ICartRepositoryService, CartRepositoryService>();  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
