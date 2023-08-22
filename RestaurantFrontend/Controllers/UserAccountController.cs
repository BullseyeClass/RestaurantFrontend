using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Store the current URL in a session variable
                HttpContext.Session.SetString("ReturnUrl", Request.Path + Request.QueryString);
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }
    }
}
