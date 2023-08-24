using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;
using System.Collections.Generic;
using System.Configuration;

namespace RestaurantFrontend.Controllers
{

    public class PopularController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public PopularController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        // /api/ProductFilter/MostPopularProduct

        [Route("Popular")]
        public async Task<IActionResult> AllPopular()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        if (allProducts.Count > 0)
                        {
                            return View("AllPopular", allProducts);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("VegetableMostPopular")]
        public async Task<IActionResult> VegetableMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> vegetablebestdeal = allProducts.Where(x => x.Tag == "Vegetables").ToList();

                        if (vegetablebestdeal.Count > 0)
                        {
                            return View("AllPopular", vegetablebestdeal);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("FruitMostPopular")]
        public async Task<IActionResult> FruitMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> fruitbestdeal = allProducts.Where(x => x.Tag == "Fruit").ToList();

                        if (fruitbestdeal.Count > 0)
                        {
                            return View("AllPopular", fruitbestdeal);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Meat&PoultryMostPopular")]
        public async Task<IActionResult> Meat_PoultryMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> MeatandPoultry = allProducts.Where(x => x.Tag == "Meat & Poultry").ToList();

                        if (MeatandPoultry.Count > 0)
                        {
                            return View("AllPopular", MeatandPoultry);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Fish_SeafoodMostPopular")]
        public async Task<IActionResult> Fish_SeafoodMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Fish_Seafood = allProducts.Where(x => x.Tag == "Fish & Seafood").ToList();

                        if (Fish_Seafood.Count > 0)
                        {
                            return View("AllPopular", Fish_Seafood);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Dairy_EggsMostPopular")]
        public async Task<IActionResult> Dairy_EggsMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Dairy_Eggs = allProducts.Where(x => x.Tag == "Dairy & Eggs").ToList();

                        if (Dairy_Eggs.Count > 0)
                        {
                            return View("AllPopular", Dairy_Eggs);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("BakeryMostPopular")]
        public async Task<IActionResult> BakeryMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Bakery = allProducts.Where(x => x.Tag == "Bakery").ToList();

                        if (Bakery.Count > 0)
                        {
                            return View("AllPopular", Bakery);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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


        [Route("Pastas_GrainsMostPopular")]
        public async Task<IActionResult> Pastas_GrainsMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Pastas_Grains = allProducts.Where(x => x.Tag == "Pastas & Grains").ToList();

                        if (Pastas_Grains.Count > 0)
                        {
                            return View("AllPopular", Pastas_Grains);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Cereals_SnacksMostPopular")]
        public async Task<IActionResult> Cereals_SnacksMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Cereals_Snacks = allProducts.Where(x => x.Tag == "Cereals & Snacks").ToList();

                        if (Cereals_Snacks.Count > 0)
                        {
                            return View("AllPopular", Cereals_Snacks);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("TeaMostPopular")]
        public async Task<IActionResult> TeaMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Tea = allProducts.Where(x => x.Tag == "Tea").ToList();

                        if (Tea.Count > 0)
                        {
                            return View("AllPopular", Tea);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("CoffeeMostPopular")]
        public async Task<IActionResult> CoffeeMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Coffee = allProducts.Where(x => x.Tag == "Coffee").ToList();

                        if (Coffee.Count > 0)
                        {
                            return View("AllPopular", Coffee);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("SoftDrinksMostPopular")]
        public async Task<IActionResult> SoftDrinksMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> SoftDrinks = allProducts.Where(x => x.Tag == "Soft Drinks").ToList();

                        if (SoftDrinks.Count > 0)
                        {
                            return View("AllPopular", SoftDrinks);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("BeerMostPopular")]
        public async Task<IActionResult> BeersMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Beer = allProducts.Where(x => x.Tag == "Beer").ToList();

                        if (Beer.Count > 0)
                        {
                            return View("AllPopular", Beer);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Home_KitchenMostPopular")]
        public async Task<IActionResult> Home_KitchenMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Home_Kitchen = allProducts.Where(x => x.Tag == "Home & Kitchen").ToList();

                        if (Home_Kitchen.Count > 0)
                        {
                            return View("AllPopular", Home_Kitchen);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("WineMostPopular")]
        public async Task<IActionResult> WineMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Wine = allProducts.Where(x => x.Tag == "Wine").ToList();

                        if (Wine.Count > 0)
                        {
                            return View("AllPopular", Wine);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Cleaning_SuppliesMostPopular")]
        public async Task<IActionResult> Cleaning_SuppliesMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {

                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Cleaning_Supplies = allProducts.Where(x => x.Tag == "Cleaning Supplies").ToList();

                        if (Cleaning_Supplies.Count > 0)
                        {
                            return View("AllPopular", Cleaning_Supplies);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("Personal_HygienesMostPopular")]
        public async Task<IActionResult> Personal_HygieneMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Personal_Hygiene = allProducts.Where(x => x.Tag == "Personal Hygiene").ToList();

                        if (Personal_Hygiene.Count > 0)
                        {
                            return View("AllPopular", Personal_Hygiene);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("BabiesMostPopular")]
        public async Task<IActionResult> BabiesMostPopularProduct()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);

                        List<Products> Babies = allProducts.Where(x => x.Tag == "Babies").ToList();

                        if (Babies.Count > 0)
                        {
                            return View("AllPopular", Babies);
                        }

                        else
                        {
                            return RedirectToAction("EmptyProduct", "Popular");
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

        [Route("NoPopularFound")]
        public IActionResult EmptyProduct()
        {

            return View();
        }

    }
}

