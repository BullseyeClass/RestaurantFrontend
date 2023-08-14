using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.Error404;

namespace RestaurantFrontend.Controllers
{
    public class ErrorMessageController : Controller
    {

        [Route("ErrorMessage")]
        public IActionResult Index(ErrorMessage errorMessage)
        {
            return View(errorMessage);
        }
    }
}
