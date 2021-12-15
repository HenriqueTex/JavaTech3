using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Models
{
    public class Shipping
    {
        public Shipping()
        {
            this.Product = new HashSet<Product>();
            
        }
        [Key]
        public int Id { get; set; }
        
        public DateTime EntryDate { get; set; }
        public int User_id { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
