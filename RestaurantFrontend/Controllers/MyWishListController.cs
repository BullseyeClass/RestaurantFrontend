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
            var myWishList = _gettingMyWishListFromDB.GetMyWishListFromDataSource();
            return View(myWishList.ToList());
        }
    }
}
