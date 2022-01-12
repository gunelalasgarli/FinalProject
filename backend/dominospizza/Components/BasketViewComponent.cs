using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Components
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;

        public BasketViewComponent(AppDbContext context, UserManager<AppUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketViewModel> basketProducts = new List<BasketViewModel>();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            if (!User.Identity.IsAuthenticated)
            {
                if (HttpContext.Request.Cookies["Basket"] != null)
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(HttpContext.Request.Cookies["Basket"]);
                }
            }
            else
            {
                basketProducts = await _context.BasketItems.Where(x => x.AppUserId == user.Id && x.IsDeleted == false).Select(x => new BasketViewModel
                {
                    Count = x.Count,
                    Image = x.Product.Image,
                    ProductId = x.ProductId,
                    Name = x.Product.Name,
                    Price = (decimal)x.Product.Price,
                    Total = (decimal)x.Product.Price * x.Count

                }).ToListAsync();
            }

            return View(basketProducts);
        }
    }
}
