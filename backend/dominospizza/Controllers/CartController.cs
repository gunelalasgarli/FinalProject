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
            if (!User.Identity.IsAuthenticated)
            {
                if (HttpContext.Request.Cookies["Basket"] != null)
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketViewModel>>(HttpContext.Request.Cookies["Basket"]);
                }
            }
            else
            {
                basketProducts = await _context.BasketItems.Where(x=>x.AppUserId==user.Id && x.IsDeleted == false).Select(x => new BasketViewModel
                {
                    Count = x.Count,
                    Image = x.Product.Image,
                    ProductId = x.ProductId,
                    Name = x.Product.Name,
                    Price = (decimal)x.Price ,
                    Total= (decimal)x.Product.Price* x.Count

                }).ToListAsync();
            }

            return View(basketProducts);
        }
        public async Task<IActionResult> AddToCart(int? Id, int count,int size)
        {

            if (Id == null) return NotFound();
            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == Id);
            string sizeStr = "";
            double price = 0;
            if (product == null) return NotFound();
            switch (size)
            {
                case 1:
                    sizeStr = "Kicik";
                    price = product.Price;
                    break;
                case 2:
                    sizeStr = "Orta";
                    price = product.Price*1.6;
                    break;
                case 3:
                    sizeStr = "Böyük";
                    price = product.Price * 2;
                    break;
                default:
                    break;
            }
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();
            string basket = HttpContext.Request.Cookies["Basket"];
            if (!User.Identity.IsAuthenticated)
            {
                #region AddCookie
                if (basket == null)
                {
                    BasketViewModel basketVM = new BasketViewModel
                    {
                        ProductId = product.Id,
                        Count = count,
                        Name = product.Name,
                        Image = product.Image,
                        Price = (decimal)price,
                        Size = sizeStr

                    };
                    
                    productBaskets.Add(basketVM);
                       
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
                            Image = product.Image,
                            Name = product.Name,
                            Price = (decimal)price,
                            Size = sizeStr

                        });
                    }
                    else
                    {
                        productBasket.Count += count;
                    }

                }
                HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));
                #endregion

                //await _context.SaveChangesAsync();
            }
            else
            {
                #region AddDatabase
                //FullOrder fullorder = new FullOrder();
                //; Order productBasket = _context.Orders.Where(x => x.FullOrderId == fullorder.Id).FirstOrDefault(x => x.ProductId == Id);
                //if (productBasket == null)
                //{
                //    _context.Orders.Add(new Order
                //    {
                //        ProductId = product.Id,
                //        Count = count,
                //        Name = product.Name,
                //        Image = product.Image,
                //        Total = (decimal)product.Price * count,
                //    });
                //}
                //else
                //{
                //    productBasket.Count += count;
                //}


                //await _context.SaveChangesAsync();
                #endregion
                BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId==product.Id && x.IsDeleted == false);
                if (memberBasketItem == null)
                {
                    memberBasketItem = new BasketItem
                    {
                        AppUserId = user.Id,
                        Count = count,
                        ProductId=product.Id,
                        CreatedAt = DateTime.Now,
                        Size = sizeStr,
                        Name=product.Name,
                        Image=product.Image,
                        Price = price


                };
                    _context.BasketItems.Add(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count+=count;
                }
               
            }
            productBaskets = _context.BasketItems.Where(x => x.AppUserId == user.Id).Select(x =>
                  new BasketViewModel
                  {
                      ProductId = product.Id,
                      Count = count,
                      Size = sizeStr,
                      Name = product.Name,
                      Image = product.Image,
                      Total = (decimal)price * count,
                  }).ToList();

            _context.SaveChanges();
               
                return RedirectToAction(nameof(Index), "Home");
        }

        //public async Task<IActionResult> PlaceOrder()
        //{
        //    string basket = HttpContext.Request.Cookies["Basket"];
        //    var productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);

        //    //return Json(productBaskets);

        //    if (!User.Identity.IsAuthenticated)
        //        return RedirectToAction("Login", "Account");

        //    var user = await _usermanager.FindByNameAsync(User.Identity.Name);
        //    if (user is null)
        //        return BadRequest();

        //    foreach (var product in productBaskets)
        //    {
        //        _context.Orders.Add(new Order
        //        {
        //            ProductId = product.ProductId,
        //            Count = product.Count,
        //            Name = product.Name,
        //            Image = product.Image,
        //            Total = (decimal)product.Price * product.Count
        //        });
        //    }

        //    await _context.SaveChangesAsync();

        //    Response.Cookies.Delete("Basket");

        //    return RedirectToAction("Index", "Home");
        //}
        [HttpPost]
        public async Task<IActionResult> EmptyCart()
        {
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;

            if (!User.Identity.IsAuthenticated)
            {
                Response.Cookies.Delete("Basket");
            }
            else
            {
                List<BasketItem> memberBasketItem =await _context.BasketItems.Where(x => x.AppUserId == user.Id && x.IsDeleted==false).ToListAsync();

                
                    _context.BasketItems.RemoveRange(memberBasketItem);
                

                _context.SaveChanges();

            }


            return RedirectToAction("Index", "Cart");

        }

        public async Task<IActionResult> RemoveFromCart(int? Id)
        {
            if (Id == null) return NotFound();
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();

            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;

            if (!User.Identity.IsAuthenticated)
            {
                string basketStr = HttpContext.Request.Cookies["Basket"];
                productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketStr);
                BasketViewModel productBasket = productBaskets.FirstOrDefault(x => x.ProductId == Id);
                if (productBasket == null) return NotFound();

                if (productBasket.Count == 1 || productBasket.Count <= 0)
                {
                    productBaskets.Remove(productBasket);
                }
                else
                {
                    productBasket.Count--;
                }


                HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));
            }
            else
            {
                BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId==Id && x.IsDeleted == false);

                if (memberBasketItem.Count == 1)
                {

                    _context.BasketItems.Remove(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count--;
                }

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}