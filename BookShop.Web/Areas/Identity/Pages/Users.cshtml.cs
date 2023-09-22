using BookShop.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BookShop.Web.Areas.Identity.Pages
{
    public class UsersModel : PageModel
    {
        private readonly UserManager<BookShopWebUser> _userManager;
        public List<BookShopWebUser>? Users { get; set; }
        [BindProperty]
        public string Filter { get; set; }
        public UsersModel(UserManager<BookShopWebUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            Users=_userManager.Users.ToList();
            for (int i=0;i<Users.Count; i++)
            {
                var check=await _userManager.GetRolesAsync(Users[i]);
                if (check.Contains("Admin"))
                {
                    Users.RemoveAt(i);
                    i--;
                }
            }
        }
        public async Task OnPost()
        {
            if (Filter is null || Filter=="")
            {
                Users = _userManager.Users.ToList();
                for (int i = 0; i < Users.Count; i++)
                {
                    var check = await _userManager.GetRolesAsync(Users[i]);
                    if (check.Contains("Admin"))
                    {
                        Users.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                Users = _userManager.Users.ToList().Where(a => a.UserName.Contains(Filter)).ToList();
                for (int i = 0; i < Users.Count; i++)
                {
                    var check = await _userManager.GetRolesAsync(Users[i]);
                    if (check.Contains("Admin"))
                    {
                        Users.RemoveAt(i);
                        i--;
                    }
                }
            }
            
        }
    }
}
