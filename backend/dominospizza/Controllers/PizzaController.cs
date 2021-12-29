using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class PizzaController : Controller
    {
        private readonly AppDbContext _context;

        public PizzaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products.Where(p => p.CategoryId == 1&& p.IsDeleted == false).Include(p=>p.ProductType).ToListAsync();
            ViewBag.Types = _context.ProductTypes.Include(x => x.Products).ToList();
            return View(product);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return NotFound();
            Product product = await _context.Products.Where(p => !p.IsDeleted && p.CategoryId == 1).FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null) return NotFound();

            return PartialView("_ModalPartial",product);
        }
    }
}
