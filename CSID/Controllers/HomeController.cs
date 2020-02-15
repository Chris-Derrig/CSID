using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSID.Models;

namespace CSID.Controllers
{
    public class HomeController : Controller
    {
        private Items tempItem = new Items();
        private AspNetUsers tempUser = new AspNetUsers();
       

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            CSIDContext db = new CSIDContext();
            return View(db);
        }

        public IActionResult Purchase(decimal? price, int Quantity)
        {

            CSIDContext db = new CSIDContext();
            CartItems cartItems = new CartItems();
            var user = User.Identity;

            foreach (Items items in db.Items)
            {
                if (items.RetailPrice == price)
                {
                    tempItem = items;
                    if (tempItem.Inventory >= 0)
                    {
                        tempItem.Inventory -= 1;
                        tempItem.ItemId = cartItems.Id;
                        tempItem.Description = cartItems.Description;
                        tempItem.CustomerDiscountPrice = cartItems.CustomerDiscountPrice;
                        db.CartItems.Add(cartItems);
                    }
                    else if (tempItem.Inventory <= 10 || tempItem.Inventory == 0)
                    {
                        return View();
                    }
                }
            }
            foreach (AspNetUsers users in db.AspNetUsers)
            {
                if (user.Name == users.Email)
                {
                    tempUser = users;
                    if (tempUser.Funds >= price)
                    {
                        tempUser.Funds -= price;
                    }
                    else if (tempUser.Funds <= price || tempUser.Funds == null)
                    {
                        return View();
                    }
                }
            }
            db.SaveChanges();
            return View("Shop", db);
        }

        public IActionResult Cart()
        {
          
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
