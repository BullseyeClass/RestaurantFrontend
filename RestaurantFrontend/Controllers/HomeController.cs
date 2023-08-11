using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models;
using RestaurantFrontend.Repository.Interface;
using System.Diagnostics;

namespace RestaurantFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGettingProductsFromDB _gettingProductsFromDB;

        public HomeController(ILogger<HomeController> logger, IGettingProductsFromDB gettingProductsFromDB)
        {
            _logger = logger;
            _gettingProductsFromDB = gettingProductsFromDB;
        }

        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Index()
        {

            var products = _gettingProductsFromDB.GetProductsFromDataSource();
            return View(products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}