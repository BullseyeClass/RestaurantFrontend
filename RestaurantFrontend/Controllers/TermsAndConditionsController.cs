using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers
{
    public class TermsAndConditionsController : Controller
    {

        [Route("Terms_Conditions")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
