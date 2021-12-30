

using JavaTech3.Data;
using JavaTech3.Models;
using JavaTech3.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _host;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
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
        public async Task<IActionResult> CreateAsync(Product obj)
        {

            if (ModelState.IsValid)
            {
                Image imageProduct = new Image();
                
                string wwwRootPath = _host.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.ImageProduct.ImageFile.FileName);
                string extension = Path.GetExtension(obj.ImageProduct.ImageFile.FileName);
                imageProduct.ImageName = fileName + DateTime.Now.ToString("yymmddffff") + extension;
                imageProduct.ImageFile = obj.ImageProduct.ImageFile;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                using( var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageProduct.ImageFile.CopyToAsync(fileStream);
                }

                Product product = new Product();
                product.ImageProduct = imageProduct;
                product.Name = obj.Name;
                product.Quantity = 0;

                
                _db.Products.Add(product);
                _db.SaveChanges();
            }            
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            VMProduct objlist = new VMProduct(_db);
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
        public IActionResult AddProductUser()
        {
         
            return View();
        }
    }
}

