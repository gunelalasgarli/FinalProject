using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Components
{
    public class NavheadViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public NavheadViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Roles = _context.Roles.ToList();

            Settings setting  = await _context.Settings.FirstOrDefaultAsync();

            
            return View(setting);
        }
    }
}
