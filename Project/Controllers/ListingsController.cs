using CampusMarket.Data;
using CampusMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace CampusMarket.Controllers
{
    public class ListingsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ListingsController(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            var query = db.Listings
                          .Include(e => e.Category);
            //.OrderBy(e => e.Date);

            ViewBag.Listings = await query.ToListAsync();

            if (TempData.ContainsKey("message"))
                ViewBag.Message = TempData["message"];

            return View();
        }

        public async Task<IActionResult> Show(int id)
        {
            Listing? ls = await db.Listings
                                .Include(e => e.Category)
                                .Include(e => e.Reviews)
                                .Where(e => e.Id == id)
                                .FirstOrDefaultAsync();

            if (ls is null)
                return NotFound();

            return View(ls);
        }

        public async Task<IActionResult> New()
        {
            Listing ls = new Listing();
            //ls.Categ = await GetAllCategories();

            return View(ls);
        }

        [HttpPost]
        public async Task<IActionResult> New(Listing ls)
        {
            try
            {
                db.Listings.Add(ls);
                await db.SaveChangesAsync();
                TempData["Message"] = "Anuntul a fost adaugat";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //ls.CategoryListing = await GetAllCategories();
                return View(ls);
            }
        }
    }
}
