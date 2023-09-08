using BookShop.Models;

namespace BookShop.Api.Data;

public static class DataInitializer
{
    public static List<Category> ReturnCategoryData() {
        List<Category> list = new()
        {
            new Category { Id=1, Name = "Classics", DisplayOrder = 1 },
            new Category { Id=2, Name = "Crime", DisplayOrder = 2 },
            new Category { Id=3, Name = "Fantasy", DisplayOrder = 3 },
            new Category { Id=4, Name = "Manual", DisplayOrder = 8 },
            new Category { Id=5, Name = "Fiction", DisplayOrder = 4 },
            new Category { Id=6, Name = "Horror", DisplayOrder = 5 }
        };
        return list;
    }
    public static List<Product> ReturnProductData()
    {
        List<Product> list = new()
        {
            new Product { Id=1, Name= "Scary book", Author="John Johne", CategoryId=1, Price=49.6M, Publisher="Bookfirm", PublishingYear=2001, QuantityInStock=2023},
            new Product { Id=2, Name= "Smart book", Author="Anna Banana", CategoryId=3, Price=490.6M, Publisher="Bookfirm", PublishingYear=2003, QuantityInStock=203},
            new Product { Id=3, Name= "Manual book", Author="Wayne Waffles", CategoryId=6, Price=56M, Publisher="Getrobook", PublishingYear=2012, QuantityInStock=5000},
            new Product { Id=4, Name= "Red book", Author="Anna Banana", CategoryId=5, Price=15.6M, Publisher="Bookfirm", PublishingYear=2020, QuantityInStock=13},
            new Product { Id=5, Name= "Yesbook", Author="John Johne", CategoryId=3, Price=15M, Publisher="Getrobook", PublishingYear=2019, QuantityInStock=17000}
        };
        return list;
    }
}
