using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;

        public LocationController( AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Location> location = await _context.Locations.Where(x=>x.IsDeleted==false).ToListAsync();
            
            return View(location);
        }
    }
}
