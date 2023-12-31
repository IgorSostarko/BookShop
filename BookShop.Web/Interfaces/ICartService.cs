﻿using BookShop.Models;

namespace BookShop.Web.Interfaces
{
    public interface ICartService
    {
        Task<bool> SetUpName(string name);
        Task<bool> AddToCart(CartProductConnection connection);
        Task<List<CartProductConnection>> GetUserCart(string name);
        Task<int> GetNumberOfItemsOfUser(string username);

    }
}
