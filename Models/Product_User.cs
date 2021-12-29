using JavaTech3.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Models
{
    public class Product_User
    {
        

        [Key]
        public int? Id { get; set; }
        public string Id_user { get; set; }
        public int? Id_product { get; set; }
        public int? Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
