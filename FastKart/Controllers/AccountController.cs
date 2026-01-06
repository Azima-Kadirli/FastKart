using FastKart.Models;
using FastKart.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FastKart.Controllers
{
    public class AccountController(UserManager<AppUser>_userManager,SignInManager<AppUser>_signManager) : Controller
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

            var result = await _userManager.CreateAsync(user,vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }

            return Ok("Ok");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var existUser = 


            return View();
        }
    }
}
