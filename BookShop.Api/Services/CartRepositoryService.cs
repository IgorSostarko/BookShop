﻿using BookShop.Api.Data;
using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Services
{
    public class CartRepositoryService : ICartRepositoryService
    {
        private readonly AppDbContext _appDbContext;
        public CartRepositoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CartExists(string id)
        {
            var cart= await _appDbContext.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (cart == default) {
                await _appDbContext.Carts.AddAsync(new Cart() { Id = id });
                await _appDbContext.SaveChangesAsync();
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<CartProductConnection> AddToCart(CartProductConnection connection)
        {
            var cartItem= await _appDbContext.CartProducts.Where(a=> a.CartId==connection.CartId && a.ProductId==connection.ProductId).FirstOrDefaultAsync();
            if (cartItem == null)
            {
                await _appDbContext.CartProducts.AddAsync(connection);
                await _appDbContext.SaveChangesAsync();
                return connection;
            }
            else
            {
                if (connection.Quantity*-1 >= cartItem.Quantity)
                {
                    _appDbContext.CartProducts.Remove(cartItem);
                    await _appDbContext.SaveChangesAsync();
                    return cartItem;
                }
                else
                {
                    cartItem.Quantity += connection.Quantity;
                    _appDbContext.CartProducts.Update(cartItem);
                    await _appDbContext.SaveChangesAsync();
                    return cartItem;
                }
                
            }
        }

        public Task<List<CartProductConnection>> GetItemsOfCart(string user)
        {
            var items= _appDbContext.CartProducts.Where(a=>a.CartId==user).Include(a=>a.Product).ThenInclude(a=>a.Category).ToList();
            return Task.FromResult(items);
        }

        public Task<int> GetNumOfItemsInCart(string username)
        {
            var number = _appDbContext.CartProducts.Where(a => a.CartId == username).Select(a => a.Quantity).Sum();
            return Task.FromResult(number);
        }
    }
}
