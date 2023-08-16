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

        [Route("AllProduct")]
        public async Task<IActionResult> AllProducts(string filter, string tag)
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    if (allProducts.Count > 0)
                    {
                        return View("Product", allProducts);
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

        [Route("MostPopuplar")]
        public async Task<IActionResult> MostPopuplarProducts()
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> mostpopular = allProducts.Where(x => x.MostPopular == true).ToList();

                    if (mostpopular.Count > 0)
                    {

                        return View("Product", mostpopular);
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

        [Route("BestDeal")]
        public async Task<IActionResult> BestDealProducts()
        {
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/FilterAllProduct");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                    List<Products> bestDeal = allProducts.Where(x => x.BestDeal == true).ToList();

                    if (bestDeal.Count > 0)
                    {

                        return View("Product", bestDeal);
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

       

        [Route("VegetablesMC")]
        public async Task<IActionResult> Vegetables(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = vegetables;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = vegetables.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = vegetables.Where(p => p.MostPopular).ToList();
                    }

                    else if (vegetables.Count > 0)
                    {
                        return View("Product", vegetables);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Fruits(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = Fruits;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = Fruits.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = Fruits.Where(p => p.MostPopular).ToList();
                    }

                    else if (Fruits.Count > 0)
                    {
                        return View("Product", Fruits);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Meat_Poultry(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = MeatandPoultry;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = MeatandPoultry.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = MeatandPoultry.Where(p => p.MostPopular).ToList();
                    }

                    else if (MeatandPoultry.Count > 0)
                    {
                        return View("Product", MeatandPoultry);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Fish_Seafood(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = FishandSeafood;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = FishandSeafood.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = FishandSeafood.Where(p => p.MostPopular).ToList();
                    }

                    else if (FishandSeafood.Count > 0)
                    {
                        return View("Product", FishandSeafood);
                    }


                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Dairy_Eggs(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = DairyandEggs;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = DairyandEggs.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = DairyandEggs.Where(p => p.MostPopular).ToList();
                    }

                    else if (DairyandEggs.Count > 0)
                    {
                        return View("Product", DairyandEggs);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Bakery(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = Bakery;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = Bakery.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = Bakery.Where(p => p.MostPopular).ToList();
                    }

                    else if (Bakery.Count > 0)
                    {
                        return View("Product", Bakery);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Pastas_Grains(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = PastasandGrains;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = PastasandGrains.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = PastasandGrains.Where(p => p.MostPopular).ToList();
                    }

                    else if (PastasandGrains.Count > 0)
                    {
                        return View("Product", PastasandGrains);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
        public async Task<IActionResult> Cereals_Snacks(string filter)
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

                    List<Products> filteredProducts = new();
                    if (filter == "All")
                    {
                        filteredProducts = CerealsandSnacks;
                    }

                    else if (filter == "Deals")
                    {
                        filteredProducts = CerealsandSnacks.Where(p => p.BestDeal).ToList();
                    }

                    else if (filter == "Most Popular")
                    {
                        filteredProducts = CerealsandSnacks.Where(p => p.MostPopular).ToList();
                    }

                    else if (CerealsandSnacks.Count > 0)
                    {
                        return View("Product", CerealsandSnacks);
                    }

                    if (filteredProducts.Count > 0)
                    {
                        return View("Product", filteredProducts);
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
