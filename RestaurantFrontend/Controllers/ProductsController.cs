using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Models.RegistrationPage;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ProductsController(IConfiguration configuration)
        {
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

                    if (vegetables.Count > 0)
                    {

                        return View("Product", vegetables);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                }

                else
                {
                    //Handle error case
                    return View();
                }


            }

        }


        [Route("Vegetables/Deals")]
        public async Task<IActionResult> VegetablesDeals()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> VegetablesandDeals = allProducts.Where(x => x.Tag == "Vegetables" && x.BestDeal == true).ToList();

                    if (VegetablesandDeals.Count > 0)
                    {

                        return View("Product", VegetablesandDeals);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                }

                else
                {
                    //Handle error case
                    return View();
                }

            }
        }


        [Route("FruitsMC")]
        public async Task<IActionResult> Fruits()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> Fruits = allProducts.Where(x => x.Tag == "Fruit").ToList();

                    if (Fruits.Count > 0)
                    {

                        return View("Product", Fruits);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                }

                else
                {
                    //Handle error case
                    return View();
                }

            }
        }

        [Route("Meat & PoultryMC")]
        public async Task<IActionResult> Meat_Poultry()
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> MeatandPoultry = allProducts.Where(x => x.Tag == "Meat & Poultry").ToList();

                    if (MeatandPoultry.Count > 0)
                    {

                        return View("Product", MeatandPoultry);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                }

                else
                {
                    //Handle error case
                    return View();
                }

            }

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

                    if (FishandSeafood.Count > 0)
                    {

                        return View("Product", FishandSeafood);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }
                   
                }

                else
                {
                    //Handle error case
                    return View();
                }
               
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

                    if (DairyandEggs.Count > 0)
                    {

                        return View("Product", DairyandEggs);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                   
                }

                else
                {
                    //Handle error case
                    return View();
                }

            }
          
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

                    List<Products> Bakery = allProducts.Where(x => x.Tag == "Bakery").ToList();

                    if (Bakery.Count > 0)
                    {

                        return View("Product", Bakery);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }

                    
                }

                else
                {
                    //Handle error case
                    return View();
                }

            }

           
        }

        [Route("Pastas_GrainsMC")]
        public async Task<IActionResult> Pastas_Grains()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> PastasandGrains = allProducts.Where(x => x.Tag == "Pastas & Grains").ToList();

                    if (PastasandGrains.Count > 0)
                    {

                        return View("Product", PastasandGrains);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }


                }

                else
                {
                    //Handle error case
                    return View();
                }

            }

        }

        [Route("Cereals_SnacksMC")]
        public async Task<IActionResult> Cereals_Snacks()
        {

            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> CerealsandSnacks = allProducts.Where(x => x.Tag == "Cereals & Snacks").ToList();

                    if (CerealsandSnacks.Count > 0)
                    {

                        return View("Product", CerealsandSnacks);
                    }

                    else
                    {
                        return RedirectToAction("EmptyProduct", "Products");
                    }


                }

                else
                {
                    //Handle error case
                    return View();
                }

            }
        }


        [Route("NoProductFound")]
        public IActionResult EmptyProduct()
        {

            return View();
        }


    }
}
