using dominospizza.DAL;
using dominospizza.Extensions;
using dominospizza.Models;
using dominospizza.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{

    [Area("Manage")]
    //[Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.SlideCount = _context.Sliders.Count();
            return View(_context.Sliders.ToList());
        }

        public IActionResult Create()
        {
            int count = _context.Sliders.Count();
            if (count >= 5)
            {
                return Content("You cannot add file than 5");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (slider.Photos == null)
            {
                return View();
            }
            int count = _context.Sliders.Count();
            if (count + slider.Photos.Length > 5)
            {
                ModelState.AddModelError("Photos", $"{5 - count} - image can select");
                return View();
            }
            foreach (IFormFile photo in slider.Photos)
            {
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} - not image type");
                    return View();
                }
                if (photo.CheckLength(200))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} - Max image length must be less than 200kb");
                    return View();
                }
                Slider newSlider = new Slider();

                string path = Path.Combine("img", "homepageslider");
                newSlider.Image = await photo.SaveImageAsync(_env.WebRootPath, path);
                await _context.Sliders.AddAsync(newSlider);

            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _context.Sliders
                .FirstOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            await _context.SaveChangesAsync();
            return View(slider);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _context.Sliders
                .FirstOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            await _context.SaveChangesAsync();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Slider slider, int? id)
        {

            if (id == null) return NotFound();
            if (slider == null) return NotFound();

            Slider slide = await _context.Sliders.FindAsync(id);

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", $"{slider.Photo.FileName} - not image type");
                return View(slide);
            }
            if (!slider.Photo.CheckLength(200))
            {
                ModelState.AddModelError("Photo", $"{slider.Photo.FileName} - Max image length must be less than 200kb");
                return View(slide);
            }


            string folder = Path.Combine("img", "slider");
            string fileName = await slider.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return Content("Error");
            }
            Helper.DeleteImage(_env.WebRootPath, folder, slider.Image);
            slide.Image = fileName;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            int count = _context.Sliders.Count();
            if (count == 1)
            {
                return Content("You can't delete last image of slider!!!");
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _context.Sliders.FirstOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();

            string path = Path.Combine("img", "slider");
            Helper.DeleteImage(_env.WebRootPath, path, slider.Image);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
