using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BookShopWebUser class
public class BookShopWebUser : IdentityUser
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Address { get; set; } = "";
    [Required]
    public string? City { get; set; }

}

