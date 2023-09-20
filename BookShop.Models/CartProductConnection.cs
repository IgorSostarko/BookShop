
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class CartProductConnection
    {
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
