using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;

        public CartController(AppDbContext context, UserManager<AppUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        public async Task<IActionResult> Index()
        {
            List<BasketViewModel> basketProducts = new List<BasketViewModel>();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            //if (user == null)
            //{
            if (HttpContext.Request.Cookies["basket"] != null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(HttpContext.Request.Cookies["basket"]);
            }
            //}
            //else
            //{
            //    basketProducts = _context.Orders.Where(x => x.AppUserId == user.Id).Select(x => new BasketViewModel
            //    {
            //        Count = x.Count,
            //        Image = x.Image,
            //        ProductId = x.ProductId,
            //        Name = x.Name,
            //        Description = x.Description,
            //        Price = x.Total
            //    }).ToList();
            //}

            return View(basketProducts);
        }
        public async Task<IActionResult> AddToCart(int? Id, int count)
        {
            if (Id == null) return NotFound();
            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) return NotFound();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();
            string basket = HttpContext.Request.Cookies["Basket"];
            //if (user == null)
            //{
            #region AddCookie
            if (basket == null)
            {
                productBaskets.Add(new BasketViewModel
                {
                    ProductId = product.Id,
                    Count = count,
                    Description = product.Description,
                    Name = product.Name,
                    Image = product.Image,
                    Price = (decimal)product.Price
                });
            }
            else
            {
                productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);
                BasketViewModel productBasket = productBaskets.FirstOrDefault(x => x.ProductId == (int)Id);
                if (productBasket == null)
                {
                    productBaskets.Add(new BasketViewModel
                    {
                        ProductId = product.Id,
                        Count = count,
                        Description = product.Description,
                        Image = product.Image,
                        Name = product.Name,
                        Price = (decimal)product.Price
                    });
                }
                else
                {
                    productBasket.Count += count;
                }

            }
            HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));
            #endregion
            //}
            //else
            //{
            #region AddDatabase
            //Order productBasket = _context.Orders.Where(x => x.AppUserId == user.Id).FirstOrDefault(x => x.ProductId == Id);
            //if (productBasket == null)
            //{
            //    _context.Orders.Add(new Order
            //    {
            //        ProductId = product.Id,
            //        Count = count,
            //        Description = product.Description,
            //        Name = product.Name,
            //        Image = product.Image,
            //        Total = (decimal)product.Price * count,
            //        AppUserId = user.Id
            //    });
            //}
            //else
            //{
            //    productBasket.Count += count;
            //}
            #endregion
            //}

            //productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);


            //await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> PlaceOrder()
        {
            string basket = HttpContext.Request.Cookies["Basket"];
            var productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);

            //return Json(productBaskets);

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            if (user is null)
                return BadRequest();

            foreach (var product in productBaskets)
            {
                _context.Orders.Add(new Order
                {
                    ProductId = product.ProductId,
                    Count = product.Count,
                    Description = product.Description,
                    Name = product.Name,
                    Phone = product.Phone,
                    Image = product.Image,
                    Total = (decimal)product.Price * product.Count,
                    AppUserId = user.Id
                });
            }

            await _context.SaveChangesAsync();

            Response.Cookies.Delete("Basket");

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult EmptyCart() 
        {
            Response.Cookies.Delete("Basket");

            return RedirectToAction("Index", "Cart");

        }

        public IActionResult RemoveFromCart(int? Id)
        {
            if (Id == null) return NotFound();
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();

            //AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;

            //if (user == null)
            //{
            string basketStr = HttpContext.Request.Cookies["Basket"];
            productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketStr);
            BasketViewModel productBasket = productBaskets.FirstOrDefault(x => x.ProductId == Id);
            if (productBasket == null) return NotFound();

            if (productBasket.Count == 1 || productBasket.Count <=0)
            {
                productBaskets.Remove(productBasket);
            }
            else
            {
                productBasket.Count--;
            }


            HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));
        //}
            //else
            //{
            //    Order product = _context.Orders.Where(x => x.AppUserId == user.Id).FirstOrDefault(x => x.ProductId == Id);
            //    if (product.Count == 1)
            //    {
            //        _context.Orders.Remove(product);
            //    }
            //    else
            //    {
            //        product.Count--;
            //    }
            //    _context.SaveChanges();
            //}
            return RedirectToAction(nameof(Index));
        }
    }
}