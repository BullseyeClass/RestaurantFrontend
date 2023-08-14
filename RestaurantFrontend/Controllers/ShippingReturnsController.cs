using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Service;

namespace RestaurantFrontend.Controllers
{
    public class ShippingReturnsController : Controller
    {
        

        [Route("Policy")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
