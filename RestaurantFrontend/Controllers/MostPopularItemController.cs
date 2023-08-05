using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Repository.Interface;
using System.Collections.Generic;

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

            var MostPopularItems = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource();

            
            return View(MostPopularItems.ToList());
        }




    }
}

