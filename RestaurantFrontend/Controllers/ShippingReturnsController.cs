using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Service;

namespace RestaurantFrontend.Controllers
{
    public class ShippingReturnsController : Controller
    {
        private readonly IGettingPolicyFromDB _gettingPolicyFromDB;

        public ShippingReturnsController(IGettingPolicyFromDB gettingPolicyFromDB)
        {
            _gettingPolicyFromDB = gettingPolicyFromDB;
        }

        [Route("Policy")]
        public IActionResult Index()
        {

            var PolicyAndTerms = _gettingPolicyFromDB.GettingPolicyFromDBs();


            return View(PolicyAndTerms.ToList());
        }

    }
}
