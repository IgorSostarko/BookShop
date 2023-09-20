using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Models
{
    public class Cart
    {
        public required string Id { get; set; }
        public IList<CartProductConnection> CartProductConnections { get; set; }

    }
}
