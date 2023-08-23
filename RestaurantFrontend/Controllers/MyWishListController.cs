using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Service;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    public class MyWishListController : Controller
    {
        private readonly IGettingMyWishList _gettingMyWishListFromDB;

        public MyWishListController(IGettingMyWishList gettingMyWishListFromDB)
        {
            _gettingMyWishListFromDB = gettingMyWishListFromDB;
        }

        [Route("MyWishList")]
        public IActionResult MyWishList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Generate the return URL with query parameters
                var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

                return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });
            }

            var myWishList = _gettingMyWishListFromDB.GetMyWishListFromDataSource();
            return View(myWishList.ToList());
        }
    }
}
