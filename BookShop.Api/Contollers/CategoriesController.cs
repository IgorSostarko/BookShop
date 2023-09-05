using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Contollers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepositoryService _categoryRepositoryService;

    public CategoriesController(ICategoryRepositoryService categoryRepositoryService)
    {
        _categoryRepositoryService = categoryRepositoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _categoryRepositoryService.GetCategoriesAsync();

        return Ok(categories);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        var category = await _categoryRepositoryService.GetCategoryByIdAsync(id);
        if (category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
    {
        if (category is null)
        {
            return BadRequest();
        }
        var createdCategory= await _categoryRepositoryService.InsertCategory(category);
        return CreatedAtAction(nameof(GetCategoryById), new { createdCategory.Id}, createdCategory);
    }
    
}