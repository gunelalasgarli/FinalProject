﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class ChickenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
