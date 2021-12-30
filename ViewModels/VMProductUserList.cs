using JavaTech3.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.ViewModels
{
    public class VMProductUserList
    {
        public List<Product_User> ProductsUsers { get; set; }
        public int? Product_id { get; set; }
        public int? ProductUser_id { get; set; }
        public string? User_id { get; set; }
        public int? Quantity { get; set; }
    }
}
