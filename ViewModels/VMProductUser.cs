using JavaTech3.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JavaTech3.Models;

namespace JavaTech3.ViewModels
{
    public class VMProductUser
    {

        public List<IdentityUser>? Users { get; set; }
        public List<Product_User>? ProductsUsers { get; set; }
        public int? Product_id { get; set; }
        public string? User_id { get; set; }
        public int? Quantity { get; set; }

        
    }
}
