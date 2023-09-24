// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BookShop.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace BookShop.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<BookShopWebUser> _userManager;
        private readonly SignInManager<BookShopWebUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(
            UserManager<BookShopWebUser> userManager,
            SignInManager<BookShopWebUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Address { get; set; }
            [Required]
            public string City { get; set; }
            public string? Role { get; set; }
        }

        private async Task LoadAsync(BookShopWebUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            Username = userName;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Address = user.Address,
                City = user.City,
                Name = user.Name,
                LastName = user.LastName,
                Role = roles[0]
            };
        }
        public List<IdentityRole> Roles { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string UserName { get; set; }
        public BookShopWebUser user { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            await  SetUserAsync();
            
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["User"] = user.UserName;
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await SetUserAsync();
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["User"] = user.UserName;
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.Role is not null)
                await _userManager.RemoveFromRoleAsync(user, (await _userManager.GetRolesAsync(user))[0]);
            user.Address = Input.Address;
            user.City = Input.City;
            user.Name = Input.Name;
            user.LastName = Input.LastName;
            if (Input.Role is not null)
                await _userManager.AddToRoleAsync(user, Input.Role);
            await _userManager.UpdateAsync(user);
            if (UserName == User.Identity.Name)
                await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profile has been updated";
            return RedirectToPage();
        }
        async Task SetUserAsync()
        {
            if (RouteData.Values["userName"] is null)
                UserName = User.Identity.Name;
            else UserName = RouteData.Values["userName"].ToString();
            Roles = _roleManager.Roles.ToList();
            var currentlyLogedUser = await _userManager.GetUserAsync(User);
            IsAdmin = (await _userManager.GetRolesAsync(currentlyLogedUser)).Contains("Admin");
            if (UserName == User.Identity.Name)
                user = currentlyLogedUser;
            else if (IsAdmin)
            {
                if ((await _userManager.GetUsersInRoleAsync("Admin")).Select(a => a.UserName).Contains(UserName))
                {
                    user = currentlyLogedUser;
                }
                else
                {
                    user = _userManager.Users.FirstOrDefault(a => a.UserName == UserName);
                }
            }
            else
            {
                user = currentlyLogedUser;
            }
        }
    }
}
