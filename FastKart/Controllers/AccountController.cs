using FastKart.Models;
using FastKart.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FastKart.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signManager,RoleManager<IdentityRole>_roleManager) : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var isExistUser = await _userManager.FindByNameAsync(vm.UserName);
            if (isExistUser is { })
            {
                ModelState.AddModelError("UserName", "UserName is already taken");
            }

            var isExistEmail = await _userManager.FindByEmailAsync(vm.EmailAddress);
            if (isExistEmail is { })
            {
                ModelState.AddModelError("EmailAddress", "This email is already taken");
            }

            AppUser user = new()
            {
                FullName = vm.FirstName + " " + vm.LastName,
                Email = vm.EmailAddress,
                UserName = vm.UserName,
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var existUser = await _userManager.FindByEmailAsync(vm.EmailAddress);
            if (existUser is null)
            {
                ModelState.AddModelError("", "Email or Username is incorrect");
                return View(vm);
            }

            var loginResult = await _userManager.CheckPasswordAsync(existUser, vm.Password);
            if (!loginResult)
            {
                ModelState.AddModelError("", "Email or Username is incorrect");
                return View(vm);
            }

            await _signManager.SignInAsync(existUser, vm.IsRemember);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await  _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "User"
            });
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Admin"
            });
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Moderator"
            });
            return Ok("Roles were created");
        }
}
}
