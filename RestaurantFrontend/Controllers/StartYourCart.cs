using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;
using System.Collections.Generic;
using System.Configuration;

namespace RestaurantFrontend.Controllers
{

    public class StartYourCart : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;



        public StartYourCart(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];

        }

        [Route("StartYourCart")]
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                      var allProducts = JsonConvert.DeserializeObject<List<MostPopularItem>>(responseBody);



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


        [Route("Deals")]
        public async Task<IActionResult> Deals()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/MostPopularProduct");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                       var allProducts = JsonConvert.DeserializeObject<List<Products>>(responseBody);


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
    }
}

