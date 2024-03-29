﻿using dominospizza.DAL;
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
            List<Product> product = await _context.Products.Where(p => p.CategoryId == 2&& p.IsDeleted == false).Include(p=>p.ProductType).Include(p => p.ProductSizes).ToListAsync();
            ViewBag.Types = _context.ProductTypes.Include(x => x.Products).ToList();
            return View(product);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return RedirectToAction("Index", "Error");
            Product product = await _context.Products.Where(p => p.IsDeleted==false && p.CategoryId == 2).FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null) return RedirectToAction("Index", "Error");

            return PartialView("_ModalPartial",product);
        }
    }
}
