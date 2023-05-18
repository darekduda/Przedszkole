using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzedszkoleData.Data.Account;
using PrzedszkoleAdmin.Models;
using PrzedszkoleData.Data;

namespace PrzedszkoleAdmin.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;


        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var viewModel = new UserDetailsViewModel
            {
                User = user,
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Kraj = user.Kraj,
                Wojewodztwo = user.Wojewodztwo,
                Miasto = user.Miasto,
                KodPocztowy = user.KodPocztowy,
                Ulica = user.Ulica,
                NumerDomu = user.NumerDomu,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Kraj = model.Kraj;
                    user.Wojewodztwo = model.Wojewodztwo;
                    user.Miasto = model.Miasto;
                    user.KodPocztowy = model.KodPocztowy;
                    user.Ulica = model.Ulica;
                    user.NumerDomu = model.NumerDomu;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }

            return View(model);
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

        [HttpGet]
        public async Task<IActionResult> AssignChildren(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var children = await _context.Dziecko.ToListAsync();

            var model = new AssignChildrenViewModel
            {
                UserId = id,
                UserName = user.UserName,
                Children = children.Select(c => new SelectListItem
                {
                    Text = $"{c.Imie} {c.Nazwisko}",
                    Value = c.Id.ToString()
                })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignChildren(AssignChildrenViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var childrenIds = model.SelectedChildrenIds?.Select(int.Parse) ?? Enumerable.Empty<int>();
            var children = await _context.Dziecko.Where(c => childrenIds.Contains(c.Id)).ToListAsync();

            user.Dzieci = children;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


    }
}