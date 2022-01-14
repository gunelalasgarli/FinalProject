//using dominospizza.DAL;
//using dominospizza.Extensions;
//using dominospizza.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace dominospizza.Areas.Manage.Controllers
//{
//    [Authorize(Roles = "Admin, Member")]

//    [Area("manage")]
//    public class FooterController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;
//        public FooterController(AppDbContext context, IWebHostEnvironment env)
//        {
//            _context = context;
//            _env = env;

//        }
//        public IActionResult Index()
//        {
//            List<Contact> contact = _context.Contacts.ToList();
//            return View(contact);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Index(Contact contact)
//        {
//            List<Contact> contactdb = _context.Contacts.ToList();
//            if (!ModelState.IsValid) return View(contactdb);
//            string path = Path.Combine("img", "homepageslider");
//            foreach (var item in contactdb)
//            {
//                if (contact.FooterImage != null)
//                {
//                    if (item.FooterLogo != null)
//                    {
//                        if (!contact.FooterImage.IsImage())
//                        {
//                            ModelState.AddModelError("PhoneImage", "Please select file in a correct form");
//                            return View();
//                        }

//                        item.FooterLogo = await contact.FooterImage.SaveImageAsync(_env.WebRootPath, path);

//                    }
//                }
//                if (contact.SocialImage != null)
//                {
//                    if (item.SocialImg != null)
//                    {

//                        if (!contact.SocialImage.IsImage())
//                        {
//                            ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
//                            return View();
//                        }

//                        item.SocialImg = await contact.SocialImage.SaveImageAsync(_env.WebRootPath, path);
//                    }
//                }

//                if (contact.PayImage != null)
//                {
//                    if (item.PayImg != null)
//                    {
//                        if (!contact.PayImage.IsImage())
//                        {
//                            ModelState.AddModelError("HeaderImage", "Please select file in a correct form");
//                            return View();
//                        }

//                        item.PayImg = await contact.PayImage.SaveImageAsync(_env.WebRootPath, path);
//                    }
//                }

//                item.SocialLink = contact.SocialLink;

//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
