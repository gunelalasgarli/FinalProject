using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, Member")]

    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public OrderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.FullOrders.AsQueryable();

            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Products.Count() / 4m);
            List<FullOrder> fullOrders = await _context.FullOrders.Include(a => a.BillingAddress).Include(a => a.Orders)
                                                                .ThenInclude(a=>a.Product).OrderByDescending(x=>x.OrderedAt)
                                                                .Where(a=>a.IsDeleted==false).Skip((page - 1) * 4).Take(4).ToListAsync();
            return View(fullOrders);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            FullOrder fullOrder = await _context.FullOrders.Include(a => a.BillingAddress).Include(a => a.Orders)
                                                           .ThenInclude(a => a.Product).FirstOrDefaultAsync(c => c.Id==id);
            return View(fullOrder);
        }
    }
}
