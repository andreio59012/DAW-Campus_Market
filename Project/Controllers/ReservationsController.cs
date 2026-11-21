using Microsoft.AspNetCore.Mvc;

namespace CampusMarket.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
