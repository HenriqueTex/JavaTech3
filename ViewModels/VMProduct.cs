using JavaTech3.Data;
using JavaTech3.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.ViewModels
{
    public class VMProduct
    {
        
        public VMProduct(ApplicationDbContext db)
        {
            Products = db.Products.ToList();

        }
        public List<Product> Products { get; set; }

        public int User_id;
        public int Product_id;
        public int Quantity;
        
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
