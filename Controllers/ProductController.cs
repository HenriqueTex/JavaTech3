

using JavaTech3.Data;
using JavaTech3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            obj.Quantity = 0;
            _db.Products.Add(obj);
            _db.SaveChanges();
            
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            IEnumerable<Product> objlist = _db.Products;
            return View(objlist);
        }
        public IActionResult Delete(Product obj)
        {
            var productToRemover = _db.Products.FirstOrDefault(s => s.Id == obj.Id);
            _db.Products.Remove(productToRemover);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = _db.Products.FirstOrDefault(product => product.Id == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            return View(productToUpdate);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Product obj)
        {
            var productToUpdate = _db.Products.FirstOrDefault(product => product.Id == obj.Id);
            productToUpdate.Name = obj.Name;
            productToUpdate.Quantity = obj.Quantity;
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}

