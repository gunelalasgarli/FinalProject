using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, Member")]

    [Area("manage")]

    public class CategoryController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Categories.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            List<Category> categories = query
               .Where(a=>a.IsDeleted==false).Skip((page - 1) * 4).Take(4).ToList();

            
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Categories.Count() / 4m);


            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.CategoryImage != null)
            {
                if (category.CategoryImage.ContentType != "image/png" && category.CategoryImage.ContentType != "image/jpeg" && category.CategoryImage.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("CategoryImage", "File type can be only image type!");
                    return View();
                }
                if (category.CategoryImage.Length > 2097152)
                {
                    ModelState.AddModelError("CategoryImage", "File size can not be more than 2MB!");
                    return View();
                }
                string fileName = category.CategoryImage.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "img/icons", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    category.CategoryImage.CopyTo(stream);
                }
                category.Image = newFileName;
            }

            if (_context.Categories.Any(x => x.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "The name is already available");
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id&& x.IsDeleted==false);

            if (category == null) return RedirectToAction("index", "error");

            return View(category);
        }

        [HttpPost]

        public IActionResult Edit(int? id, Category category)
        {
            if (!ModelState.IsValid) return NotFound();

            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id && x.IsDeleted==false);

            if (existCategory == null) return RedirectToAction("index", "error");

            if (category.CategoryImage != null)
            {
                if (category.CategoryImage.ContentType != "image/png" && category.CategoryImage.ContentType != "image/jpeg" && category.CategoryImage.ContentType != "image/jfif")
                {
                    ModelState.AddModelError("CategoryImage", "File type can be only jpeg,jpg,jfif or png!");
                    return View(existCategory);
                }
                if (category.CategoryImage.Length > 2097152)
                {
                    ModelState.AddModelError("CategoryImage", "File size can not be more than 2MB!");
                    return View(existCategory);
                }

                string fileName = category.CategoryImage.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "img/icons", newFileName);

                if (existCategory.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "img/icons", existCategory.Image);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    category.CategoryImage.CopyTo(stream);
                }
                existCategory.Image = newFileName;
            }
            else if (category.Image == null && existCategory.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "img/icons", existCategory.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existCategory.Image = null;
            }

            existCategory.Name = category.Name;

            if (_context.Categories.Any(x => x.Name.ToLower() == category.Name.ToLower() && x.Id != id))
            {
                ModelState.AddModelError("Name", "Bu category artiq movcuddur!!");
                return View();
            }

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted==false);
            if (category == null) return RedirectToAction("index");

            try
            {
                category.IsDeleted = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("index","error occured");
            }

            return RedirectToAction("index");
        }
    }
}
