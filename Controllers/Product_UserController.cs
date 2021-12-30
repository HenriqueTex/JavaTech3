using JavaTech3.Data;
using JavaTech3.Models;
using JavaTech3.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Claims;

namespace JavaTech3.Controllers
{
    public class Product_UserController : Controller
    {
       
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public Product_UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        
        public async Task<IActionResult> IndexAsync()
        {
            
            var userLoggedIn = await _userManager.GetUserAsync(User);
            var productsFromUser = new VMProductUserList();
            productsFromUser.ProductsUsers = _db.Product_Users.Where(s => s.Id_user == userLoggedIn.Id.ToString()).ToList();
            
            foreach(var item in productsFromUser.ProductsUsers)
            {
                item.Product_ = _db.Products.FirstOrDefault(s => s.Id == item.Id_product);
            }
            productsFromUser.User_id = userLoggedIn.Id;
            
            return View(productsFromUser);
        }
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
            }
            VMProductUser productUser = new VMProductUser();
            productUser.Product_id = id;
            productUser.Users = _db.Users.ToList();
            return View(productUser);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(VMProductUser productUser2)
        {
            var existProductUser = _db.Product_Users.FirstOrDefault(s => s.Id_product == productUser2.Product_id && s.Id_user == productUser2.User_id);
            var product = _db.Products.FirstOrDefault(s => s.Id == productUser2.Product_id);
            if (existProductUser == null)
            {
                Product_User newProductUser = new Product_User();
                newProductUser.Id_product = productUser2.Product_id;
                newProductUser.Id_user = productUser2.User_id;
                newProductUser.Quantity = productUser2.Quantity;
                newProductUser.Product_ = _db.Products.FirstOrDefault(s => s.Id == productUser2.Product_id);
                newProductUser.User = _db.Users.FirstOrDefault(s => s.Id==productUser2.User_id);
                _db.Add(newProductUser);
            }
            else
            {
                existProductUser.Quantity += productUser2.Quantity;
            }
            product.Quantity -= (int)productUser2.Quantity;
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Whitdrawal(VMProductUserList productWhitdrawal)
        {
            var product = _db.Product_Users.FirstOrDefault(s => s.Id == productWhitdrawal.ProductUser_id);
            product.Quantity -= productWhitdrawal.Quantity;

            var whitdrawal = new Whitdrawal();
            whitdrawal.Product_id = productWhitdrawal.Product_id ?? 0;
            whitdrawal.ProductUser_id = productWhitdrawal.ProductUser_id??0;
            whitdrawal.Quantity_Exit = productWhitdrawal.Quantity??0;
            whitdrawal.User_id = productWhitdrawal.User_id;
            whitdrawal.ExitDate = DateTime.Now;
            whitdrawal._Product = _db.Products.FirstOrDefault(s => s.Id == whitdrawal.Product_id);
            whitdrawal._User = _db.Users.FirstOrDefault(s => s.Id == whitdrawal.User_id);

            _db.Add(whitdrawal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
