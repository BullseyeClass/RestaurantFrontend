using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers
{
    public class StartYourCart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
