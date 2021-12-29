using JavaTech3.Data;
using JavaTech3.Models;

using JavaTech3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShippingController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Shipping> shippings = _db.Shippings.OrderByDescending(s=>s.EntryDate);
            return View(shippings);
        }

        public IActionResult Create()
        {
            ShippingViewModel shippingVM = new ShippingViewModel();
            shippingVM.Products = _db.Products.ToList();
            shippingVM.EntryDate = DateTime.Today;
            return View(shippingVM);
        }
        public IActionResult ProductCreate(Shipping obj )
        {
            
            ShippingViewModel shippingVM = new ShippingViewModel();
            shippingVM.ShippingProducts = _db.shippingProducts.Where(s=>s.Id_remessa==obj.Id).ToList();
            shippingVM.Products = _db.Products.ToList();
            shippingVM.Shipping_id = obj.Id ;
            shippingVM.Product = _db.Products.FirstOrDefault(s => s.Id == obj.Id);

            

            return View(shippingVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ProductCreate(ShippingViewModel obj)
        {
            
            ShippingProduct shippingProduct = new ShippingProduct();
            shippingProduct.Id_product = obj.Product_id;
            shippingProduct.Id_remessa = obj.Shipping_id;
            shippingProduct.Quantity = obj.Quantity;
            shippingProduct.Product = _db.Products.FirstOrDefault(s => s.Id == obj.Product_id);
            _db.shippingProducts.Add(shippingProduct);
            

            var productQtd = _db.Products.FirstOrDefault(s => s.Id == shippingProduct.Id_product);
            productQtd.Quantity += shippingProduct.Quantity;

            ShippingViewModel shippingVM = new ShippingViewModel();
            shippingVM.ShippingProducts = _db.shippingProducts.Where(s => s.Id_remessa == obj.Shipping_id).ToList();
            shippingVM.Products = _db.Products.ToList();
            shippingVM.Product = _db.Products.FirstOrDefault(s => s.Id == obj.Product_id);

            _db.SaveChanges();
            //return RedirectToAction("Index");
            return View(shippingVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShippingViewModel obj)
        {
            Shipping shipping = new Shipping();
            shipping.EntryDate = obj.EntryDate;
            shipping.User_id = obj.User_id;
            shipping.Image = obj.Image;

            _db.Shippings.Add(shipping);
            _db.SaveChanges();
            
            
            //return RedirectToAction("Index");
            return RedirectToAction("ProductCreate","Shipping",shipping);
        }


        public IActionResult Delete(int? id)
        {
            var shippingToRemove = _db.Shippings.FirstOrDefault(s => s.Id == id);

            var productsOnShipping = _db.shippingProducts.Where(s => s.Id_remessa == shippingToRemove.Id);

            foreach(var product in productsOnShipping){
                var productQtd = _db.Products.FirstOrDefault(s => s.Id == product.Id_product);
                productQtd.Quantity -= product.Quantity;
                _db.shippingProducts.Remove(product);
            }
           
            _db.Shippings.Remove(shippingToRemove);
            _db.SaveChanges();

            
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            ShippingViewModel shippingVM = new ShippingViewModel();
            shippingVM.ShippingProducts = _db.shippingProducts.Where(s => s.Id_remessa == id).ToList();
            shippingVM.Products = _db.Products.ToList();
            shippingVM.Shipping_id = id ?? 0;
            shippingVM.Product = _db.Products.FirstOrDefault(s => s.Id == id);



            return View(shippingVM);
        }

    }
}

