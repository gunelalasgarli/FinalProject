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

namespace dominospizza.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SettingController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            Settings settings = _context.Settings.FirstOrDefault();
            return View(settings);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Settings setting)
        {
            Settings settingsDb = _context.Settings.FirstOrDefault();
            if (!ModelState.IsValid) return View(settingsDb);
            string path = Path.Combine("img", "headpics");
            if (setting.PhoneImage != null)
            {
                if (settingsDb.PhoneImg != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, settingsDb.PhoneImg);
                    if (!setting.PhoneImage.IsImage())
                    {
                        ModelState.AddModelError("PhoneImage", "Please select file in a correct form");
                        return View();
                    }
                    if (setting.PhoneImage.CheckLength(200))
                    {
                        ModelState.AddModelError("PhoneImage", "File is too long");
                        return View();
                    }
                    settingsDb.PhoneImg = await setting.PhoneImage.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            if (setting.HeaderImage != null)
            {
                if (settingsDb.HeaderLogo != null)
                {
                    Helper.DeleteImage(_env.WebRootPath, path, settingsDb.HeaderLogo);
                    if (!setting.HeaderImage.IsImage())
                    {
                        ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
                        return View();
                    }
                    if (setting.HeaderImage.CheckLength(200))
                    {
                        ModelState.AddModelError("HeaderImage", "File is too long");
                        return View();
                    }
                    settingsDb.HeaderLogo = await setting.HeaderImage.SaveImageAsync(_env.WebRootPath, path);
                }
            }
            settingsDb.PhoneNum = setting.PhoneNum;
            settingsDb.Copyright = setting.Copyright;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
