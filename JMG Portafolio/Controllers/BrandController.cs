using JMG_Portafolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JMG_Portafolio.Controllers
{
    public class BrandController : Controller
    {
        private readonly MyDatabaseContext _context;

        public BrandController(MyDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }
    }
}
