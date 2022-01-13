using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using dominospizza.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<AppUser> usermanager)
        {
            _logger = logger;
            _context = context;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketViewModel> basketProducts = new List<BasketViewModel>();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;

            if (User.Identity.IsAuthenticated)
            {
                if (HttpContext.Request.Cookies["Basket"] != null)
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(HttpContext.Request.Cookies["Basket"]);
                    BasketItem memberBasketItem = await _context.BasketItems.FirstOrDefaultAsync(x => x.AppUserId == user.Id);

                    foreach (var item in basketProducts)
                    {

                        memberBasketItem = new BasketItem
                        {
                            AppUserId = user.Id,
                            Count = item.Count,
                            ProductId = item.ProductId,
                            CreatedAt = DateTime.Now,
                            Size = item.Size,
                            Name = item.Name,
                            Image = item.Image,
                            Price = (double)item.Price


                        };
                        await _context.BasketItems.AddAsync(memberBasketItem);

                        await _context.SaveChangesAsync();

                    }

                    Response.Cookies.Delete("Basket");
                }
            }
            HomeVM homeVM = new HomeVM
            {
               
                Sliders = await _context.Sliders.ToListAsync(),
                Settings= await _context.Settings.SingleOrDefaultAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
                HomePages = await _context.HomePages.SingleOrDefaultAsync()
            };
            return View(homeVM);
        }

    }
}
