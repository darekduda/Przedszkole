using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleAdmin.Models;
using PrzedszkoleData.Data.Account;

namespace PrzedszkoleAdmin.Controllers
{
    public class RoleAdUser : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleAdUser(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.ToListAsync();

            var model = new AssignRoleViewModel
            {
                UserId = id,
                UserName = user.UserName,
                Roles = roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByNameAsync(model.Role);
            if (role == null)
            {
                ModelState.AddModelError("", "Invalid role selected");
                return View(model);
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user from current roles");
                return View(model);
            }

            result = await _userManager.AddToRoleAsync(user, role.Name);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to assign role to user");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
