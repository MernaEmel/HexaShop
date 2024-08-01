using HexaShop.Data;
using HexaShop.Models;
using HexaShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HexaShop.Controllers
{
    public class ProductsController(ApplicationDbContext _db) : Controller
    {
        public IActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int NoOfSkiproducts = (int)(page - 1) * 9;
            var Products = _db.products.Include(m => m.category).Skip(NoOfSkiproducts).Take(9).ToList();
            var allProducts = new ShopViewModel()
            {
                products = Products,
                CurrentPage = (int)page,
                pages = (int)Math.Ceiling(_db.products.Count() / 9.0),
            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();

            return View(allProducts);
        }
        public IActionResult BagsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 5).Where(m => m.ShopId == 8).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult PantsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 4).Where(m => m.ShopId == 4).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult DressShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 5).Where(m=>m.ShopId==5).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,
             
            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);

        }
           
        
        public IActionResult TopsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 5).Where(m => m.ShopId == 6).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }

        public IActionResult JacketsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 4).Where(m => m.ShopId == 1).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult SneakersShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 5).Where(m => m.ShopId == 7).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult ShirtsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 4).Where(m => m.ShopId == 2).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult ShortsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 4).Where(m => m.ShopId == 3).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult GirlsShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 6).Where(m => m.ShopId == 9).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult BoysShop()
        {
            var Products = _db.products.Where(m => m.CategoryId == 6).Where(m => m.ShopId == 10).ToList();
            var AllProducts = new ShopViewModel()
            {
                products = Products,

            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(AllProducts);
        }
        public IActionResult SingleProduct(int id)
        {
            var product = _db.products.Include(m => m.category).SingleOrDefault(m=>m.Id==id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(product);
        }

        #region Cart
        public  IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = _db.Cart.Include(m => m.product).Where(c => c.UserId == userId).ToList();
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return View(products);
        }
        public IActionResult AddtoCart(int id)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var CartProduct = _db.Cart.Where(c => c.UserId == userId).SingleOrDefault(m => m.ProductId == id);
			if (CartProduct == null)
			{
                var AddedProoduct = new Cart()
                {

                    ProductId = id,
                    Quantity = 1,
					UserId = userId
				};
				_db.Cart.Add(AddedProoduct);
               
            }
			else
			{
				CartProduct.Quantity += 1;
			}

            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
           
            _db.SaveChanges();
            return RedirectToAction("Cart");
		}
        public IActionResult RemoveProduct(int id)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var removedproduct = _db.Cart.Where(c => c.UserId == userId).SingleOrDefault(m => m.ProductId == id);
			if (removedproduct != null)
			{
				_db.Cart.Remove(removedproduct);
			}
			_db.SaveChanges();
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return RedirectToAction("Cart");
		}
        public IActionResult UpdateQuantity(int quantity,int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var UpdatedProduct = _db.Cart.Where(c => c.UserId == userId).SingleOrDefault(c => c.Id == id);

            if (quantity > 0)
            {
                UpdatedProduct.Quantity = quantity;

            }
            else
            {
                _db.Cart.Remove(UpdatedProduct);
            }
            _db.SaveChanges();
            ViewData["Counter"] = _db.Cart.Where(c => c.UserId == userId).Count();
            return RedirectToAction("Cart");
        }
        #endregion



    }
}
