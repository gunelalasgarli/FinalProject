using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
               
                Sliders = await _context.Sliders.ToListAsync(),
                Settings= await _context.Settings.SingleOrDefaultAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
                HomePages = await _context.HomePages.SingleOrDefaultAsync()


            };

            return View(homeVM);
        }

        

       
    }
}
