using dominospizza.Areas.Manage.ViewModels;
using dominospizza.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin, Member")]

    [Area("manage")]

    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DashboardController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            DashboardViewModel DashboardViewModel = new DashboardViewModel
            {
                Orders = _context.Orders.ToList(),
                Messages = _context.Messages.ToList(),
                FullOrders = _context.FullOrders.ToList(),

            };

            return View(DashboardViewModel);
        }
    }
}
