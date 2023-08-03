using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Controllers
{

    public class PopularController : Controller
    {

        private readonly IGettingMostPopularItem _gettingMostPopularItemsFromDB;

        public PopularController(IGettingMostPopularItem gettingJobsFromDB)
        {
            _gettingMostPopularItemsFromDB = gettingJobsFromDB;
        }
        public IActionResult Index()
        {
            var MostPopularItem = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource();

            return View(MostPopularItem.ToList());
        }

        //public IActionResult Index()
        //{

        //    return View();
        //}



    }
}

