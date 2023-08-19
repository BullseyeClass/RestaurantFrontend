using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
