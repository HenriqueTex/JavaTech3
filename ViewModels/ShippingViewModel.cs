using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaTech3.Models;

namespace JavaTech3.ViewModels
{
    public class ShippingViewModel
    {
        //public ShippingViewModel(int quantity, string image, int shipping_id, DateTime entryDate, int user_id)
        //{
        //    Quantity = quantity;
        //    Image = image;
        //    Shipping_id = shipping_id;
        //    EntryDate = entryDate;
        //    User_id = user_id;
        //    Product_id = new List<int>();
        //    Name = new List<string>();
        //}

        public List<Product> Products { get; set; }
        public List<ShippingProduct> ShippingProducts { get; set; }

        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public int Shipping_id { get; set; }
        public DateTime EntryDate { get; set; }
        public int User_id { get; set; }
        public bool Onlist { get; set; }

        public virtual Product Product { get; set; }
        
    }
}
