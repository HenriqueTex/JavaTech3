using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Models
{
    public class ShippingProduct
    {
        [Key]
        public int Id { get; set;}
        public int Id_remessa { get; set; }
        public int Id_product { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
