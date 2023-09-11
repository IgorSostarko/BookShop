using System.ComponentModel.DataAnnotations;

namespace BookShop.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    public string? Author { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required]
    public string? Publisher { get; set; }
    public int PublishingYear { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [Required]
    public int QuantityInStock { get; set; }



}
