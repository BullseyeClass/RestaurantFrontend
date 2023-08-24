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
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }

        }

        [Route("MostPopuplar")]
        public async Task<IActionResult> MostPopuplarProducts()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }

        [Route("BestDeal")]
        public async Task<IActionResult> BestDealProducts()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }



        [Route("VegetablesMC")]
        public async Task<IActionResult> Vegetables(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }


        [Route("FruitsMC")]
        public async Task<IActionResult> Fruits(string filter)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }
        }

        [Route("Meat & PoultryMC")]
        public async Task<IActionResult> Meat_Poultry(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }

        }

        [Route("Fish & SeafoodMC")]
        public async Task<IActionResult> Fish_Seafood(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }
        }

        [Route("Dairy & EggsMC")]
        public async Task<IActionResult> Dairy_Eggs(string filter)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }
            }

        }

        [Route("BakeryMC")]
        public async Task<IActionResult> Bakery(string filter)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }


        }

        [Route("Pastas_GrainsMC")]
        public async Task<IActionResult> Pastas_Grains(string filter)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }
            }

        }

        [Route("Cereals_SnacksMC")]
        public async Task<IActionResult> Cereals_Snacks(string filter)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }
        }

        [Route("TeaMC")]
        public async Task<IActionResult> Tea(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Tea = allProducts.Where(x => x.Tag == "Tea").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Tea;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Tea.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Tea.Where(p => p.MostPopular).ToList();
                        }

                        else if (Tea.Count > 0)
                        {
                            return View("Product", Tea);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }

        [Route("CoffeeMC")]
        public async Task<IActionResult> Coffee(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Coffee = allProducts.Where(x => x.Tag == "Coffee").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Coffee;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Coffee.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Coffee.Where(p => p.MostPopular).ToList();
                        }

                        else if (Coffee.Count > 0)
                        {
                            return View("Product", Coffee);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }



            }

        }

        [Route("SoftDrinksMC")]
        public async Task<IActionResult> SoftDrinks(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> SoftDrinks = allProducts.Where(x => x.Tag == "Soft Drinks").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = SoftDrinks;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = SoftDrinks.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = SoftDrinks.Where(p => p.MostPopular).ToList();
                        }

                        else if (SoftDrinks.Count > 0)
                        {
                            return View("Product", SoftDrinks);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }

        [Route("BeerMC")]
        public async Task<IActionResult> Beer(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Beer = allProducts.Where(x => x.Tag == "Beer").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Beer;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Beer.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Beer.Where(p => p.MostPopular).ToList();
                        }

                        else if (Beer.Count > 0)
                        {
                            return View("Product", Beer);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }


        [Route("WineMC")]
        public async Task<IActionResult> Wine(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Wine = allProducts.Where(x => x.Tag == "Wine").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Wine;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Wine.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Wine.Where(p => p.MostPopular).ToList();
                        }

                        else if (Wine.Count > 0)
                        {
                            return View("Product", Wine);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }

        }


        [Route("Home_KitchenMC")]
        public async Task<IActionResult> Home_Kitchen(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Home_Kitchen = allProducts.Where(x => x.Tag == "Home & Kitchen").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Home_Kitchen;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Home_Kitchen.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Home_Kitchen.Where(p => p.MostPopular).ToList();
                        }

                        else if (Home_Kitchen.Count > 0)
                        {
                            return View("Product", Home_Kitchen);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }


            }

        }

        [Route("CleaningSuppliesMC")]
        public async Task<IActionResult> CleaningSupplies(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> CleaningSupplies = allProducts.Where(x => x.Tag == "Cleaning Supplies").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = CleaningSupplies;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = CleaningSupplies.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = CleaningSupplies.Where(p => p.MostPopular).ToList();
                        }

                        else if (CleaningSupplies.Count > 0)
                        {
                            return View("Product", CleaningSupplies);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }



            }

        }

        [Route("PersonalHygieneMC")]
        public async Task<IActionResult> PersonalHygiene(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> PersonalHygiene = allProducts.Where(x => x.Tag == "Personal Hygiene").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = PersonalHygiene;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = PersonalHygiene.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = PersonalHygiene.Where(p => p.MostPopular).ToList();
                        }

                        else if (PersonalHygiene.Count > 0)
                        {
                            return View("Product", PersonalHygiene);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }
            }

        }

        [Route("BabiesMC")]
        public async Task<IActionResult> Babies(string filter)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/AllProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Babies = allProducts.Where(x => x.Tag == "Babies").ToList();

                        List<Products> filteredProducts = new();
                        if (filter == "All")
                        {
                            filteredProducts = Babies;
                        }

                        else if (filter == "Deals")
                        {
                            filteredProducts = Babies.Where(p => p.BestDeal).ToList();
                        }

                        else if (filter == "Most Popular")
                        {
                            filteredProducts = Babies.Where(p => p.MostPopular).ToList();
                        }

                        else if (Babies.Count > 0)
                        {
                            return View("Product", Babies);
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
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
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
