using dominospizza.DAL;
using dominospizza.Helpers;
using dominospizza.Models;
using dominospizza.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;

        public AccountController(
                                AppDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect!");
                return View();
            }
            return RedirectToAction("index", "home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterVM signup)
        {
            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser()
            {
                UserName = signup.UserName,
                Email = signup.Email
            };


            bool isExistUserName = _userManager.Users.Any(us => us.UserName == newUser.UserName);
            if (isExistUserName)
            {
                ModelState.AddModelError("", "This username already exist. Please use another username");
                return View();
            }


            bool isExistEmail = _userManager.Users.Any(us => us.Email == newUser.Email);
            if (isExistEmail)
            {
                ModelState.AddModelError("", "This Email already exist. Please use another username");
                return View();
            }

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, signup.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            //await _userManager.AddToRoleAsync(newUser, "Admin");

            await _signInManager.SignInAsync(newUser, true);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //public async Task CreateRole()
        //{
        //    if ((!await _roleManager.RoleExistsAsync(Helper.Roles.Admin.ToString())))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Helper.Roles.Admin.ToString()));
        //    }

        //    if ((!await _roleManager.RoleExistsAsync(Helper.Roles.Member.ToString())))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Helper.Roles.Member.ToString()));
        //    }

        //}

    }
}
