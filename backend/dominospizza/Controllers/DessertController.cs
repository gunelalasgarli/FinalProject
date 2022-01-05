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
    public class DessertController : Controller
    {
        private readonly AppDbContext _context;

        public DessertController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products.Where(p => p.CategoryId == 7).Where(p => p.IsDeleted == false).ToListAsync();

            return View(product);
        }
    }
}
