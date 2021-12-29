using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.Controllers
{
    public class DrinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
