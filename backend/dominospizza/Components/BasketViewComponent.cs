using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Components
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public BasketViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> product = await _context.Products.ToListAsync();
            return View(product);
        }
    }
}
