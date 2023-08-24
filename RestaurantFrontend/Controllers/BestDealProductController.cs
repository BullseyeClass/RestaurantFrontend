using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Products;
using System.Configuration;

namespace RestaurantFrontend.Controllers
{
    public class BestDealProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public BestDealProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }


        [Route("BestDealProduct")]
        public async Task<IActionResult> AllBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        if (allProducts.Count > 0)
                        {
                            return View("AllBestDealProduct", allProducts);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("VegetableBestDeal")]
        public async Task<IActionResult> VegetableBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> vegetablebestdeal = allProducts.Where(x => x.Tag == "Vegetables").ToList();

                        if (vegetablebestdeal.Count > 0)
                        {
                            return View("AllBestDealProduct", vegetablebestdeal);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("FruitBestDeal")]
        public async Task<IActionResult> FruitBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> fruitbestdeal = allProducts.Where(x => x.Tag == "Fruit").ToList();

                        if (fruitbestdeal.Count > 0)
                        {
                            return View("AllBestDealProduct", fruitbestdeal);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Meat&PoultryBestDeal")]
        public async Task<IActionResult> Meat_PoultryBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> MeatandPoultry = allProducts.Where(x => x.Tag == "Meat & Poultry").ToList();

                        if (MeatandPoultry.Count > 0)
                        {
                            return View("AllBestDealProduct", MeatandPoultry);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Fish_SeafoodBestDeal")]
        public async Task<IActionResult> Fish_SeafoodBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Fish_Seafood = allProducts.Where(x => x.Tag == "Fish & Seafood").ToList();

                        if (Fish_Seafood.Count > 0)
                        {
                            return View("AllBestDealProduct", Fish_Seafood);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Dairy_EggsBestDeal")]
        public async Task<IActionResult> Dairy_EggsBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Dairy_Eggs = allProducts.Where(x => x.Tag == "Dairy & Eggs").ToList();

                        if (Dairy_Eggs.Count > 0)
                        {
                            return View("AllBestDealProduct", Dairy_Eggs);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("BakeryBestDeal")]
        public async Task<IActionResult> BakeryBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Bakery = allProducts.Where(x => x.Tag == "Bakery").ToList();

                        if (Bakery.Count > 0)
                        {
                            return View("AllBestDealProduct", Bakery);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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


        [Route("Pastas_GrainsBestDeal")]
        public async Task<IActionResult> Pastas_GrainsBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Pastas_Grains = allProducts.Where(x => x.Tag == "Pastas & Grains").ToList();

                        if (Pastas_Grains.Count > 0)
                        {
                            return View("AllBestDealProduct", Pastas_Grains);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Cereals_SnacksBestDeal")]
        public async Task<IActionResult> Cereals_SnacksBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Cereals_Snacks = allProducts.Where(x => x.Tag == "Cereals & Snacks").ToList();

                        if (Cereals_Snacks.Count > 0)
                        {
                            return View("AllBestDealProduct", Cereals_Snacks);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("TeaBestDeal")]
        public async Task<IActionResult> TeaBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Tea = allProducts.Where(x => x.Tag == "Tea").ToList();

                        if (Tea.Count > 0)
                        {
                            return View("AllBestDealProduct", Tea);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("CoffeeBestDeal")]
        public async Task<IActionResult> CoffeeBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {

                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Coffee = allProducts.Where(x => x.Tag == "Coffee").ToList();

                        if (Coffee.Count > 0)
                        {
                            return View("AllBestDealProduct", Coffee);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("SoftDrinksBestDeal")]
        public async Task<IActionResult> SoftDrinksBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> SoftDrinks = allProducts.Where(x => x.Tag == "Soft Drinks").ToList();

                        if (SoftDrinks.Count > 0)
                        {
                            return View("AllBestDealProduct", SoftDrinks);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("BeerBestDeal")]
        public async Task<IActionResult> BeersBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Beer = allProducts.Where(x => x.Tag == "Beer").ToList();

                        if (Beer.Count > 0)
                        {
                            return View("AllBestDealProduct", Beer);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Home_KitchenBestDeal")]
        public async Task<IActionResult> Home_KitchenBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Home_Kitchen = allProducts.Where(x => x.Tag == "Home & Kitchen").ToList();

                        if (Home_Kitchen.Count > 0)
                        {
                            return View("AllBestDealProduct", Home_Kitchen);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("WineBestDeal")]
        public async Task<IActionResult> WineBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Wine = allProducts.Where(x => x.Tag == "Wine").ToList();

                        if (Wine.Count > 0)
                        {
                            return View("AllBestDealProduct", Wine);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Cleaning_SuppliesBestDeal")]
        public async Task<IActionResult> Cleaning_SuppliesBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Cleaning_Supplies = allProducts.Where(x => x.Tag == "Cleaning Supplies").ToList();

                        if (Cleaning_Supplies.Count > 0)
                        {
                            return View("AllBestDealProduct", Cleaning_Supplies);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("Personal_HygienesBestDeal")]
        public async Task<IActionResult> Personal_HygieneBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Personal_Hygiene = allProducts.Where(x => x.Tag == "Personal Hygiene").ToList();

                        if (Personal_Hygiene.Count > 0)
                        {
                            return View("AllBestDealProduct", Personal_Hygiene);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("BabiesBestDeal")]
        public async Task<IActionResult> BabiesBestDealProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/BestDealProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Babies = allProducts.Where(x => x.Tag == "Babies").ToList();

                        if (Babies.Count > 0)
                        {
                            return View("AllBestDealProduct", Babies);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "BestDealProduct");
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

        [Route("NoBestDealProductFound")]
        public IActionResult EmptyProduct()
        {

            return View();
        }
    }
}
