using Microsoft.AspNetCore.Mvc;

namespace CampusMarket.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
