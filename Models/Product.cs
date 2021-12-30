using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Models
{
    public class Product
    {
        public Product()
        {
            this.Shipping = new HashSet<Shipping>();
            this.ShippingProduct = new HashSet<ShippingProduct>();
            this.Product_Users = new HashSet<Product_User>();
            this.Whitdrawals = new HashSet<Whitdrawal>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Shipping> Shipping { get; set; }
        public virtual ICollection<ShippingProduct> ShippingProduct { get; set; }
        public virtual ICollection<Product_User> Product_Users { get; set; }
        public virtual ICollection<Whitdrawal> Whitdrawals { get; set; }
    }
}
