using BookShop.Api.Interfaces;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Contollers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepositoryService _productRepositoryService;

    public ProductsController(IProductRepositoryService productRepositoryService)
    {
        _productRepositoryService = productRepositoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int? categoryId, [FromQuery] decimal? startPrice, [FromQuery] decimal? endPrice, [FromQuery] string? author, [FromQuery] string? name)
    {
        List<Product> products;
        if (categoryId is null)
        {
            products = (List<Product>)await _productRepositoryService.GetProductsAsync();
        }
        else
        {
            products= (List<Product>)await _productRepositoryService.GetProductsOfCategoryAsync(categoryId??1);
        }
        if (startPrice is not null) { 
            products=products.Where(a=>a.Price>=startPrice).ToList();
        }
        if (endPrice is not null)
        {
            products=products.Where(a=>a.Price<=endPrice).ToList();
        }
        if (name is not null)
        {
            products=products.Where(a=>a.Name.Contains(name)).ToList();
        }
        if (author is not null)
        {
            products = products.Where(a => a.Author.Contains(author)).ToList();
        }
        return Ok(products);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productRepositoryService.GetProductByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }
        var createdProduct = await _productRepositoryService.InsertProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { createdProduct.Id }, createdProduct);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
    {
        var productToUpdate = await _productRepositoryService.GetProductByIdAsync(product.Id);
        if (productToUpdate == null)
        {
            return NotFound();
        }
        var update = await _productRepositoryService.UpdateProductAsync(productToUpdate, product);
        return Ok(update);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var productToUpdate = await _productRepositoryService.GetProductByIdAsync(id);
        if (productToUpdate == null)
        {
            return NotFound();
        }
        var delete = await _productRepositoryService.DeleteProduct(productToUpdate);
        return Ok(delete);
    }
    [HttpGet("validate-name")]
    public async Task<bool> ValidateName([FromQuery] string name)
    {
        var response = await _productRepositoryService.ValidateName(name);
        return response;
    }
}
