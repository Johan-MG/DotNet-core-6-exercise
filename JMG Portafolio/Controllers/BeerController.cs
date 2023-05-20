using JMG_Portafolio.Models;
using JMG_Portafolio.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JMG_Portafolio.Controllers
{
    public class BeerController : Controller
    {
        private readonly MyDatabaseContext _dbContext;

        public BeerController(MyDatabaseContext context)
        {
            _dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var beers = _dbContext.Beers.Include(beer => beer.Brand);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_dbContext.Brands, "Brandid", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel vw_model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Name = vw_model.Name,
                    Brandid = vw_model.BrandId
                };
                _dbContext.Add(beer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brands"] = new SelectList(_dbContext.Brands, "Brandid", "Name", vw_model.BrandId);
            return View(vw_model);
        }
    }
}
