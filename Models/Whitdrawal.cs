using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Models
{
    public class Whitdrawal
    {
        [Key]
        public int Id { get; set; }
        public string User_id { get; set; }
        public int Product_id { get; set; }
        public int ProductUser_id { get; set; }
        public DateTime ExitDate { get; set;}

        public int Quantity_Exit { get; set; }

        public virtual Product _Product { get; set; }
        public virtual IdentityUser _User { get; set; }
    }
}
