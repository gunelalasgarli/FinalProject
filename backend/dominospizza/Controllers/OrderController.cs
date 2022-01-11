using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<FullOrder> fullOrders = _context.FullOrders.Include(x => x.Orders).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            return View(fullOrders);
        }
       
        public async Task<IActionResult> PlaceOrder()
        {

            List<FullOrder> fullOrders = _context.FullOrders.Include(x => x.Orders).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            foreach (var item in fullOrders)
            {
                _context.FullOrders.Add(new FullOrder
                {
                    OrderDescription = item.OrderDescription,
                    Address = item.Address,
                    Phone = item.Phone,
                    CreatedAt = item.CreatedAt,
                    TotalAmount = item.TotalAmount,
                    AppUserId = user.Id
                });
            }

            await _context.SaveChangesAsync();

            Response.Cookies.Delete("Basket");

            return RedirectToAction("Index", "Home");
        }

    }
}
