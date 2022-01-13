using dominospizza.DAL;
using dominospizza.Models;
using dominospizza.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit;
using MimeKit.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;

namespace dominospizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;


        public OrderController(AppDbContext context, UserManager<AppUser> userManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            List<FullOrder> fullOrders = _context.FullOrders.Include(x => x.Orders).Include(x=>x.BillingAddress).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            return View(fullOrders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(BillingAddress billingAddress)
        {
            TempData["Success"] = false;

            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");

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
                    Total = (decimal)item.Price,
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

            //email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Dominos Pizza", "blueoceanelexample@gmail.com"));

            message.To.Add(new MailboxAddress(appUser.FullName, appUser.Email));
            message.Subject = "Order Confirmed";

            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "templates", "Order.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            string orderTem = string.Empty;

            foreach (var item in order.Orders)
            {
                string tr = @$"<tr>
                     <td width=\""75 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.Name} </td>
                     <td width=\""25 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.Count}X{item.Total}AZN </td>
                </tr>";

                orderTem += tr;
            }
            string TotalA = order.TotalAmount.ToString("F2");
            emailbody = emailbody.Replace("{{total}}",TotalA).Replace("{{orderItems}}", orderTem);

            

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("blueoceanelexample@gmail.com", "Blue@123");
            smtp.Send(message);
            smtp.Disconnect(true);



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
