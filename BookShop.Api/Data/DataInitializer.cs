using BookShop.Models;

namespace BookShop.Api.Data;

public static class DataInitializer
{
    public static List<Category> ReturnCategoryData() {
        List<Category> list = new()
        {
            new Category { Id=1, Name = "Classics", DisplayOrder = 1 },
            new Category { Id=2, Name = "Crime", DisplayOrder = 2 },
            new Category { Id=3, Name = "Fantasy", DisplayOrder = 1 },
            new Category { Id=4, Name = "Manual", DisplayOrder = 8 },
            new Category { Id=5, Name = "Fiction", DisplayOrder = 4 },
            new Category { Id=6, Name = "Horror", DisplayOrder = 1 }
        };
        return list;
    }
}
