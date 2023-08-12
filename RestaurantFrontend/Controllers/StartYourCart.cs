using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Repository.Interface;
using System.Collections.Generic;

namespace RestaurantFrontend.Controllers
{

    public class StartYourCart : Controller
    {

        private readonly IGettingMostPopularItem _gettingMostPopularItemsFromDB;

        public StartYourCart(IGettingMostPopularItem gettingJobsFromDB)
        {
            _gettingMostPopularItemsFromDB = gettingJobsFromDB;
        }

        [Route("StartYourCart")]
        public IActionResult Index()
        {

            var StartYourCart = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource();


            return View(StartYourCart.ToList());
        }

        [Route("Deals")]
        public IActionResult Deals()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Deals");



            return View("Index", products);
        }




    }
}

