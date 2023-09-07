using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
