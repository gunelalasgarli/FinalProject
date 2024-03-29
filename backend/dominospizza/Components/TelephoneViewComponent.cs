﻿using dominospizza.DAL;
using dominospizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Components
{
    public class TelephoneViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public TelephoneViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Settings setting = await _context.Settings.FirstOrDefaultAsync();


            return View(setting);
        }
    }
}
