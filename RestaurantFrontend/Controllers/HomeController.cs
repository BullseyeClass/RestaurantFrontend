using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.CartItems;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;
using System.Diagnostics;
using System.Net.Http;

namespace RestaurantFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        public IActionResult Testing()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        return View(allProducts);
                    }
                    else
                    {

                        return RedirectToAction("Index", "ErrorMessage");
                    }


                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }
            }
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
    }
}