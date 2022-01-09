using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dominospizza.Helpers;
using Microsoft.AspNetCore.Hosting;
using dominospizza.Extensions;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, Member")]

    [Area("manage")]
    public class HomePageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomePageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            HomePage homePage = _context.HomePages.FirstOrDefault();
            return View(homePage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(HomePage homePage)
        {
            HomePage homePagesdb = _context.HomePages.FirstOrDefault();
            if (!ModelState.IsValid) return View(homePagesdb);
            string path = Path.Combine("img", "homepageslider");
            if (homePage.SectionImage1 != null)
            {
                if (homePagesdb.SectionImg1 != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, homePagesdb.SectionImg1);
                    if (!homePage.SectionImage1.IsImage())
                    {
                        ModelState.AddModelError("PhoneImage", "Please select file in a correct form");
                        return View();
                    }
                    if (homePage.SectionImage1.CheckLength(200))
                    {
                        ModelState.AddModelError("PhoneImage", "File is too long");
                        return View();
                    }
                    homePagesdb.SectionImg1 = await homePage.SectionImage1.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            if (homePage.SectionImage2 != null)
            {
                if (homePagesdb.SectionImg2 != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, homePagesdb.SectionImg2);
                    if (!homePage.SectionImage2.IsImage())
                    {
                        ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
                        return View();
                    }
                    if (homePage.SectionImage2.CheckLength(200))
                    {
                        ModelState.AddModelError("HeaderImage", "File is too long");
                        return View();
                    }
                    homePagesdb.SectionImg2 = await homePage.SectionImage2.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            
            if (homePage.SectionImage3 != null)
            {
                if (homePagesdb.SectionImg3 != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, homePagesdb.SectionImg3);
                    if (!homePage.SectionImage3.IsImage())
                    {
                        ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
                        return View();
                    }
                    if (homePage.SectionImage3.CheckLength(200))
                    {
                        ModelState.AddModelError("HeaderImage", "File is too long");
                        return View();
                    }
                    homePagesdb.SectionImg3 = await homePage.SectionImage3.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            if (homePage.SignImage1 != null)
            {
                if (homePagesdb.SignImg != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, homePagesdb.SignImg);
                    if (!homePage.SignImage1.IsImage())
                    {
                        ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
                        return View();
                    }
                    if (homePage.SignImage1.CheckLength(200))
                    {
                        ModelState.AddModelError("HeaderImage", "File is too long");
                        return View();
                    }
                    homePagesdb.SignImg = await homePage.SignImage1.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            homePagesdb.Title1 = homePage.Title1;
            homePagesdb.Title2 = homePage.Title2;
            homePagesdb.Subtitle1 = homePage.Subtitle1;
            homePagesdb.Subtitle2 = homePage.Subtitle2;
            homePagesdb.Description1 = homePage.Description1;
            homePagesdb.Description2 = homePage.Description2;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
