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
    public class LocationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public LocationsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index( int page =1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Locations.Count() / 4m);
            List<Location> locations = await _context.Locations.Where(x=>x.IsDeleted == false).ToListAsync();
            return View(locations);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Location location)
        {
            Location locationsdb = await _context.Locations.FirstOrDefaultAsync(x => x.IsDeleted == false);
            if (!ModelState.IsValid) return View(locationsdb);
            locationsdb.Name = location.Name;
            locationsdb.Phone = location.Phone;
            locationsdb.Address = location.Address;
            locationsdb.OpeningTime = location.OpeningTime;
            locationsdb.ClosingTime = location.ClosingTime;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {
            Location location = await _context.Locations.FirstOrDefaultAsync();
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted==false);
            if (location == null)
            {
                return RedirectToAction("index");
            }

            if (_context.Locations.Count() == 2)
            {
                return RedirectToAction("index");
            }

            location.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (location == null)
            {
                return RedirectToAction("index");
            }
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Location location)
        {
          
            Location existLocation = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted==false);
           
            if (existLocation == null)
            {
                return RedirectToAction("index");
            }
          
                
            if (!ModelState.IsValid)
            {
                return View();
            }

            existLocation.Name = location.Name;
            existLocation.Address = location.Address;
            existLocation.Phone = location.Phone;
            existLocation.OpeningTime = location.OpeningTime;
            existLocation.ClosingTime = location.ClosingTime;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}