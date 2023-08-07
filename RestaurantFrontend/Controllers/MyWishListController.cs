using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Service;

namespace RestaurantFrontend.Controllers
{
    public class MyWishListController : Controller
    {
        private readonly IGettingMyWishList _gettingMyWishListFromDB;

        public MyWishListController(IGettingMyWishList gettingMyWishListFromDB)
        {
            _gettingMyWishListFromDB = gettingMyWishListFromDB;
        }
        public IActionResult MyWishList()
        {
            var MyWishList = _gettingMyWishListFromDB.GetMyWishListFromDataSource();
            return View(MyWishList.ToList());
        }
    }
}
