using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(BillingAddress billingAddress)
        {
            TempData["Success"] = false;

            if (!ModelState.IsValid) return NotFound();

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            List<BasketItem> basketItems = await _context.BasketItems
                .Include(b => b.Product)
                .Where(b => b.IsDeleted == false && b.AppUserId == appUser.Id)
                .ToListAsync();

            if (basketItems.Count <= 0)
            {
                TempData["Error"] =true;
                return RedirectToAction("Index", "Home");
            }

            int? orderNo = _context.Orders.OrderByDescending(o => o.Id).FirstOrDefault()?.No;

            billingAddress.AppUserId = appUser.Id;

            FullOrder order = new FullOrder
            {
                AppUserId = appUser.Id,
                No = (int)(orderNo == null ? 1000 : orderNo++),
                OrderedAt = DateTime.UtcNow.AddHours(4),
                BillingAddress = billingAddress,
            };

            List<Order> orderItems = new List<Order>();

            int orderItemNo = 0;
            double total = 0;

            foreach (BasketItem item in basketItems)
            {
                orderItemNo++;
                Order orderItem = new Order
                {
                    No = orderItemNo,
                    Count = item.Count,
                    Total = (decimal)item.Product.Price,
                    ProductId = item.ProductId,
                    Name=item.Name,
                    Image=item.Image,
                    Size=item.Size
                };

                total += (orderItem.Count * (double)orderItem.Total);

                orderItems.Add(orderItem);
                item.IsDeleted = true;

            }

            order.TotalAmount = total;
            order.Orders = orderItems;

            await _context.FullOrders.AddAsync(order);
            await _context.SaveChangesAsync();

            TempData["Success"] = true;

           
        
            return RedirectToAction("Index", "Order");
        }
    }

    //private void _addOrderItem(ref FullOrder fullOrder, BasketItem basketItem,Product product, int count)
    //{
    //    Order order = new Order
    //    {
    //        ProductId = basketItem.ProductId,
    //        Name = product.Name,
    //        Image=product.Image,
    //        Count = count,
    //        Total = (decimal)product.Price * count

    //    };

    //    fullOrder.Orders.Add(order);
    //}


    //public async Task<IActionResult> PlaceOrder()
    //{

    //    List<FullOrder> fullOrders = _context.FullOrders.Include(x => x.Orders).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
    //    var user = await _userManager.FindByNameAsync(User.Identity.Name);


    //    foreach (var item in fullOrders)
    //    {
    //        _context.FullOrders.Add(new FullOrder
    //        {
    //            OrderDescription = item.OrderDescription,
    //            Address = item.Address,
    //            Phone = item.Phone,
    //            CreatedAt = item.CreatedAt,
    //            TotalAmount = item.TotalAmount,
    //            AppUserId = user.Id
    //        });
    //    }

    //    await _context.SaveChangesAsync();

    //    Response.Cookies.Delete("Basket");

    //     List<BasketItem> memberBasketItem =await _context.BasketItems.Where(x => x.AppUserId == user.Id).ToListAsync();

    //       _context.BasketItems.RemoveRange(memberBasketItem);

    //       _context.SaveChanges();

    //    return RedirectToAction("Index", "Home");
    //}

}
