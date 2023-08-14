using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Models.RegistrationPage;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGettingProductsFromDB _gettingProductsFromDB;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ProductsController(IGettingProductsFromDB gettingProductsFromDB, IConfiguration configuration)
        {
            _gettingProductsFromDB = gettingProductsFromDB;
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }


        [Route("VegetablesMC")]
        public async Task<IActionResult> Vegetables()
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> vegetables = allProducts.Where(x => x.Tag == "Vegetables").ToList();

                    return View("Product", vegetables);
                }

                else
                {
                    //Handle error case
                        return View();
                }

                
            }

            //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Vegetables");

            //return View("Product", products);
        }


        [Route("Vegetables/Deals")]
        public IActionResult VegetablesDeals()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Vegetables" && x.BestDeal);

            return View("Product", products);
        }


        [Route("FruitsMC")]
        public IActionResult Fruits()
        {
            var product = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fruit");

            return View("Product", product);
        }

        [Route("Meat & PoultryMC")]
        public IActionResult Meat_Poultry()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Meat & Poultry");

            return View("Product", products);
        }

        [Route("Fish & SeafoodMC")]
        public async Task<IActionResult> Fish_Seafood()
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> FishandSeafood = allProducts.Where(x => x.Tag == "Fish & Seafood").ToList();

                    return View("Product", FishandSeafood);
                }

                else
                {
                    //Handle error case
                    return View();
                }
                //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fish & Seafood");

                //return View("Product", products);
            }
        }

        [Route("Dairy & EggsMC")]
        public async Task<IActionResult> Dairy_Eggs()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> DairyandEggs = allProducts.Where(x => x.Tag == "Dairy & Eggs").ToList();

                    return View("Product", DairyandEggs);
                }

                else
                {
                    //Handle error case
                    return View();
                }

                //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fish & Seafood");

                //return View("Product", products);
            }
            //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Dairy & Eggs");

            //return View("Product", products);
        }

        [Route("BakeryMC")]
        public async Task<IActionResult> Bakery()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> DairyandEggs = allProducts.Where(x => x.Tag == "Dairy & Eggs").ToList();

                    return View("Product", DairyandEggs);
                }

                else
                {
                   
                    return View();
                }

                //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fish & Seafood");

                //return View("Product", products);
            }

            //var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Bakery");

            //return View("Product", products);
        }

        [Route("Pastas_GrainsMC")]
        public IActionResult Pastas_Grains()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Dairy & Eggs");

            return View("Product", products);
        }

        [Route("Cereals_SnacksMC")]
        public IActionResult Cereals_Snacks()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Bakery");

            return View("Product", products);
        }



    }
}
