using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers
{
    public class UserAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
