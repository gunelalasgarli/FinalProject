using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, Member")]

    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Products.Count() / 4m);
            List<Product> lists =await _context.Products.Include(a => a.Category).Skip((page - 1) * 4).Take(4).ToListAsync();
            return View(lists);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            Product list = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (list == null)
            {
                return RedirectToAction("index");
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Product existproduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (!await _context.Categories.AnyAsync(x => x.Id == product.CategoryId)) return RedirectToAction("index");
            if (existproduct == null)
            {
                return RedirectToAction("index");
            }
            if (product.ProductImage != null)
            {
                if (product.ProductImage.ContentType != "image/png" && product.ProductImage.ContentType != "image/")
                {
                    ModelState.AddModelError("Image", "Shekil formatinda file daxil edilmelidir");
                    return View();
                }
                if (product.ProductImage.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("Image", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + product.ProductImage.FileName;
                var path = Path.Combine(rootPath, "img/Product", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.ProductImage.CopyTo(stream);
                }
                if (existproduct.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "img/Product", existproduct.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existproduct.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existproduct.CategoryId = product.CategoryId;
            existproduct.Price = product.Price;
            existproduct.Name = product.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Create()
        {
            Product product = await _context.Products.Include(p => p.Category).Include(t => t.ProductType).FirstOrDefaultAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
           
            ViewBag.Categories = await _context.Categories.ToListAsync();
            if (!await _context.Categories.AnyAsync(x => x.Id == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Xetaniz var!");
            }
            ViewBag.ProductTypes = await _context.ProductTypes.ToListAsync();
           
            if (!await _context.ProductTypes.AnyAsync(x => x.Id == product.ProductTypeId))
            {
                ModelState.AddModelError("ProductTypeId", "Xetaniz var!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (product.ProductImage != null)
            {
                if (product.ProductImage.ContentType != "image/png" && product.ProductImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (product.ProductImage.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + product.ProductImage.FileName;
                var path = Path.Combine(rootPath, "img/Product", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.ProductImage.CopyTo(stream);
                }
                product.Image = fileName;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            Product list = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (list == null)
            {
                return RedirectToAction("index");
            }

            if (_context.Products.Count() == 2)
            {
                return RedirectToAction("index");
            }

            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "img/Product", list.Image);
            System.IO.File.Delete(path);

            _context.Products.Remove(list);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}

