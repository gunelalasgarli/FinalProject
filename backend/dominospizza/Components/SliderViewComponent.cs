using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Components
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM homeVM = new HomeVM { Sliders = await _context.Sliders.ToListAsync() };

            return View(await Task.FromResult(homeVM));
        }
    }
}
