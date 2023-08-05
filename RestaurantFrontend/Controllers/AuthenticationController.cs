using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.RegistrationPage;
using System.Diagnostics;

namespace RestaurantFrontend.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public IActionResult Login(Login login)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            return View();
        }
    }
}
