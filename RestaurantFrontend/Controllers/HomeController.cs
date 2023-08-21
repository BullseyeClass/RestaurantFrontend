using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.CartItems;
using RestaurantFrontend.Repository.Interface;
using System.Diagnostics;

namespace RestaurantFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGettingProductsFromDB _gettingProductsFromDB;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IGettingProductsFromDB gettingProductsFromDB, IMemoryCache memoryCache)
        {
            _logger = logger;
            _gettingProductsFromDB = gettingProductsFromDB;
            _memoryCache = memoryCache;
        }

        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Index()
        {
            _memoryCache.Set("MyCachedDataKey", 1, TimeSpan.FromMinutes(10));
            var products = _gettingProductsFromDB.GetProductsFromDataSource();
            return View(products.ToList());
        }

        public IActionResult Login()
        {
            return View();
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

        //public int CalculateTotalCartQuantity()
        //{
        //    if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
        //    {
        //        int totalQuantity = cartItems.Sum(item => item.Quantity);
        //        //return totalQuantity;
        //        return 2;
        //    }

        //    return 0;
        //}


        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);

        //    int totalCartQuantity = CalculateTotalCartQuantity();
        //    //ViewBag.TotalCartQuantity = totalCartQuantity;
        //    ViewBag.TotalCartQuantity = 3;
        //}
    }
}