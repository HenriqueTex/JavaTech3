using JavaTech3.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaTech3.Controllers
{
    public class FeedWhitdrawalController : Controller
    {
        private readonly ApplicationDbContext _db;
        

        public FeedWhitdrawalController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            var teste = _db.Whitdrawals;
            return View(teste);
        }
    }
}
