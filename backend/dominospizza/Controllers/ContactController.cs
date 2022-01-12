using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage(Message message)
        {
            TempData["Success"] = false;

            if (!ModelState.IsValid) return NotFound();

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            message.AppUserId = appUser.Id;
            message.CreatedAt = DateTime.Now;

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();


            TempData["Success"] = true;

            return RedirectToAction("Index", "Contact");
        }
    }
}
