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
    public class CopyrightViewComponent : ViewComponent
    {
         
        private readonly AppDbContext _context;

        public CopyrightViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Settings settings = await _context.Settings.FirstOrDefaultAsync();

            return View(settings);
        
    }
}
}
