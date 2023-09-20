﻿using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepositoryService _cartRepositoryService;

        public CartsController(ICartRepositoryService cartRepositoryService)
        {
            _cartRepositoryService = cartRepositoryService;
        }
        [HttpGet("create/{id}")]
        public async Task<ActionResult<bool>> CheckIfExistsAndCreate(string id)
        {
            var check = await _cartRepositoryService.CartExists(id);
            return Ok(check);
        }
    }
}
