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
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MessagesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Messages.AsQueryable();

            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Products.Count() / 4m);
            List<Message> messages = await _context.Messages.OrderByDescending(x => x.CreatedAt)
                                                                .Skip((page - 1) * 4).Take(4).ToListAsync();
            return View(messages);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Message message = await _context.Messages.FirstOrDefaultAsync(c => c.Id == id);
            return View(message);
        }
    }
}
