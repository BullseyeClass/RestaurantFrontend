using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MostPopularProducts;
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

        [Route("Vegetables")]
        public IActionResult Vegetables()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Vegetables");

            return View("Index", products);
        }

        [Route("Fruits")]
        public IActionResult Fruits()
        {
            var product = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Fruit");

            return View("Index", product);
        }

        [Route("Meat_Poultry")]
        public IActionResult Meat_Poultry()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Meat & Poultry");

            return View("Index", products);
        }

        [Route("Fish_Seafood")]
        public IActionResult Fish_Seafood()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Fish & Seafood");

            return View("Index", products);
        }

        [Route("Dairy_Eggs")]
        public IActionResult Dairy_Eggs()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Dairy & Eggs");

            return View("Index", products);
        }

        [Route("Bakery")]
        public IActionResult Bakery()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Bakery");

            return View("Index", products);
        }

        [Route("Pastas_Grains")]
        public IActionResult Pastas_Grains()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Pastas_Grains");

            return View("Index", products);
        }

        [Route("Cereals_Snacks")]
        public IActionResult Cereals_Snacks()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Cereals_Snacks");

            return View("Index", products);
        }

        [Route("Tea")]
        public IActionResult Tea()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Tea");

            return View("Index", products);
        }

        [Route("Coffee")]
        public IActionResult Coffee()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Coffee");

            return View("Index", products);
        }

        [Route("Soft_Drinks")]
        public IActionResult Soft_Drinks()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Soft_Drinks");

            return View("Index", products);
        }

        [Route("Beer")]
        public IActionResult Beer()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Beer");

            return View("Index", products);
        }

        [Route("Wine")]
        public IActionResult Wine()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Wine");

            return View("Index", products);
        }

        [Route("Home_Kitchen")]
        public IActionResult Home_Kitchen()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Home_Kitchen");

            return View("Index", products);
        }

        [Route("Cleaning_Supplies")]
        public IActionResult Cleaning_Supplies()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Cleaning_Supplies");

            return View("Index", products);
        }

        [Route("Personal_Hygiene")]
        public IActionResult Personal_Hygiene()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Personal_Hygiene");

            return View("Index", products);
        }

        [Route("Babies")]
        public IActionResult Babies()
        {
            var products = _gettingMostPopularItemsFromDB.GetMostPopularItemFromDataSource().Where(x => x.Tag == "Babies");

            return View("Index", products);
        }

    }
}

