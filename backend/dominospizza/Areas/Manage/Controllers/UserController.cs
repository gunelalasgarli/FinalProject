using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static dominospizza.Helpers.Helper;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Area("Manage")]
    
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserController(
            UserManager<AppUser> userManager,
            IWebHostEnvironment env,
            AppDbContext context,
            SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
            _context = context;
            _signInManager = signInManager;
        }
        #region Index

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = _userManager.Users.Where(u => u.isDelete == false)
                .OrderByDescending(us => us.FullName).ToList();
            List<AppUserVM> appuserVM = new List<AppUserVM>();
            foreach (AppUser user in users)
            {
                
                AppUserVM userVM = new AppUserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    isDelete = user.isDelete,
                    isActive = user.isActive,
                    Role = (await _userManager.GetRolesAsync(user))[0],
                };
                appuserVM.Add(userVM);
            }
            return View(appuserVM);
        }
        #endregion
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region Activation
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Activation(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.isActive = !user.isActive;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.isDelete = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (user.isDelete)
                user.isDelete = false;
            else
                user.isDelete = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Activation")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> ActivationPost(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (user.isDelete)
                user.isDelete = false;
            else
                user.isDelete = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Change Password

        public IActionResult ChangePassword(string id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string Id, string Password)
        {
            if (Id == null) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null) return NotFound();

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            await _userManager.ResetPasswordAsync(appUser, token, Password);

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(string id, ResetPasswordVM changePass)
        //{
        //    if (!ModelState.IsValid) return Content("Some Problem is occured");

        //    AppUser appUser = await _userManager.FindByIdAsync(id);
        //    if (appUser == null)
        //    {
        //        ModelState.AddModelError("Password", "User is undefined");
        //        return View();
        //    }

        //    String getPassToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
        //    await _userManager.ResetPasswordAsync(appUser, getPassToken, changePass.Password);
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion

        #region Update User
        public IActionResult UpdateUser(string id)
        {
            if (id == null) return NotFound();
            AppUser user = _userManager.Users.FirstOrDefault(c => c.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(string id, AppUser userNewParam)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            AppUserVM appUserVM = new AppUserVM
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                UserName = user.UserName,
                isDelete = user.isDelete,
                Roles = new List<string> { "Admin", "Member", "User" }
            };

            #region check username
            bool isExistUserName = _userManager.Users.Where(us => us.isDelete == false).Any(us => us.UserName == userNewParam.UserName);
            AppUser hasUserName = _userManager.Users.Where(us => us.isDelete == false).FirstOrDefault(us => us.Id == id);
            if (isExistUserName)
            {
                if (hasUserName.UserName != userNewParam.UserName)
                {
                    ModelState.AddModelError("UserName", "This username already exist. Please use another username");
                    return View();
                }

            }
            #endregion
            #region Check email
            bool isExistEmail = _userManager.Users.Any(us => us.Email == userNewParam.Email);
            AppUser hasEmail = _userManager.Users.Where(us => us.isDelete == false).FirstOrDefault(us => us.Id == id);
            if (isExistEmail)
            {
                if (hasEmail.Email != userNewParam.Email)
                {
                    ModelState.AddModelError("Email", "This Email already exist. Please use another username");
                    return View();
                }
            }
            #endregion

            user.FullName = userNewParam.FullName;
            user.Email = userNewParam.Email;
            user.UserName = userNewParam.UserName;
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, true);

            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        //#region Change Role
        //public async Task<IActionResult> ChangeRole(string id)
        //{
        //    if (id == null) return NotFound();
        //    AppUser user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return NotFound();
        //    AppUserVM userVM = await GetAppUserVMAsync(user);
        //    return View(userVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangeRole(string id, string role)
        //{
        //    if (id == null || role == null) return NotFound();

        //    AppUser user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return NotFound();
        //    string oldRole = (await _userManager.GetRolesAsync(user))[0];

        //    switch (role)
        //    {
        //        case "Admin":
        //            if (!user.UserName.ToLower().Contains("admin"))
        //            {
        //                user.UserName = user.UserName + "Admin";
        //            }
        //            break;
        //        default:
        //            if (user.UserName.Contains("Admin"))
        //            {
        //                user.UserName = user.UserName.Replace("Admin", "");
        //            }
        //            break;
        //    }



        //    IdentityResult identityResult = await _userManager.AddToRoleAsync(user, role);


        //    if (!identityResult.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Some problem is exist");
        //        AppUserVM userVM = await GetAppUserVMAsync(user);
        //        return View(userVM);
        //    }
        //    IdentityResult removeResult = await _userManager.RemoveFromRoleAsync(user, oldRole);
        //    if (!removeResult.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Some problem is exist");
        //        AppUserVM userVM = await GetAppUserVMAsync(user);
        //        return View(userVM);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        //#endregion
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string Id)
        {
            if (Id == null) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(appUser);

            AppUserVM appUserVM = new AppUserVM
            {
                Id = appUser.Id,
                FullName = appUser.FullName,
                Email = appUser.Email,
                UserName = appUser.UserName,
                isDelete = appUser.isDelete,
                Roles = new List<string> { "Admin", "Member","User" },
                Role = userRoles.Count > 0 ? (await _userManager.GetRolesAsync(appUser))[0] : ""
            };

            return View(appUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]


        public async Task<IActionResult> ChangeRole(string Id, string Roles)
        {
            if (Id == null) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(appUser);

            if (userRoles.Count > 0)
            {
                string oldRole = (await _userManager.GetRolesAsync(appUser))[0];

                await _userManager.RemoveFromRoleAsync(appUser, oldRole);
            }


            await _userManager.AddToRoleAsync(appUser, Roles);

            return RedirectToAction("Index");
        }



        

        public async Task<IActionResult> Detail(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        //private async Task<AppUserVM> GetAppUserVMAsync(AppUser user)
        //{
        //    List<string> roles = new List<string> { Roles.Admin.ToString(), Roles.Member.ToString() };
        //    AppUserVM userVM = new AppUserVM
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        UserName = user.UserName,
        //        FullName = user.FullName,
        //        Role = (await _userManager.GetRolesAsync(user))[0],
        //        Roles = roles,
        //    };
        //    return userVM;
        //}
    }
}
