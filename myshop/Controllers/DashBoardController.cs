using HexaShop.Data;
using HexaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using myshop.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;
using HexaShop.Utility;

namespace myshop.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment hosting;

        public DashBoardController(ApplicationDbContext db,IHostingEnvironment hosting)
        {

            _db = db;
            this.hosting=hosting;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult AddProduct()
        {

            return View();
        }
      
        [HttpPost]
       
        public IActionResult AddProduct(Product product)
        {
            //if(!ModelState.IsValid)
            //{
            //   return View(product);

            //}
            if(product.Image!=null)
            {
                string ImageFolder = Path.Combine(hosting.WebRootPath, "images/newImages");
                string imagePath = Path.Combine(ImageFolder, product.Image.FileName);
                product.Image.CopyTo(new FileStream(imagePath,FileMode.Create));
                product.ImagePath = product.Image.FileName;
            }
            _db.products.Add(product);
          _db.SaveChanges();
        
            return RedirectToAction("Index");
        }


        #region ViewProduct
        [Authorize(Roles = RL.RoleAdmin)]

        public IActionResult ViewProduct()
        {
            var product = _db.products.Include(x => x.category).ToList();
            return View(product);
        }
        #endregion




        #region DeleteProduct
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult DeleteProduct(int id)
        {
            Product product=_db.products.FirstOrDefault(x=>x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ViewProduct");
        }
        #endregion




        #region EditProduct
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult EditProduct(int id)
        {
            Product product1=_db.products.FirstOrDefault(x=>x.Id==id);
            return View(product1);
        }
        [HttpPost]
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult EditProduct(Product product)
        {
            Product product1=_db.products.FirstOrDefault(x=>x.Id==product.Id);
            product1.Name= product.Name;
            product1.Price= product.Price;
            product1.Quantity= product.Quantity;
            product1.CategoryId= product.CategoryId;
            product1.ShopId= product.ShopId;
            _db.products.Update(product1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }


}

