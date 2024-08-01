using HexaShop.Data;
using HexaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myshop.Models;

using System.Diagnostics;
using System.Security.Claims;

namespace myshop.Controllers
{
    public class HomeController (ApplicationDbContext _db): Controller
    {

        public IActionResult Index()
        {
            var PRODUCT=_db.products.Include(m => m.category).ToList();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(PRODUCT);
        }
       
        public IActionResult About()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View();
        }

        public IActionResult Contact()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View();
        }
        [HttpPost]
        public IActionResult Submit(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact", model);
            }
            _db.contacts.Add(model);
            _db.SaveChanges();  

            return RedirectToAction("Contact");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
