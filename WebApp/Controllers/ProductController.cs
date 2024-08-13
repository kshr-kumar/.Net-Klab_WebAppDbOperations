using DBFirst;
using DBFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            var products = _db.Products.ToList();

            //var products = (from prd in _db.Products
            //            select prd).ToList();

            return View(products);
        }
        
        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.ToList();

            //Product product = new Product();
            //var data = _db.Procedures.usp_getproductAsync(id).Result.FirstOrDefault();
            //if (data != null)
            //{
            //    product.ProductId = data.ProductId;
            //    product.Name = data.Name;
            //    product.Price = data.Price;
            //}
            //return View(product);

            var product = _db.Products.Find(id);
            return View(product);
        }
        
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            //for partial update 
            //var model = _db.Products.Find(product.ProductId);
            //model.name = product.Name;
            //model.Price = product.Price;


            //We hit db only once. EF 7
            //_db.Products.Where(p => p.ProductId == product.ProductId).ExecuteUpdate(e => e.SetProperty(p=>p.Name, product.Name));
            

            //full update - here we are hitting the database only once.
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);

        }


        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if(product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
