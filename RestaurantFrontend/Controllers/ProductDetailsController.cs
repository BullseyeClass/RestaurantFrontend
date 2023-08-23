using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.ProductDetails;
using RestaurantFrontend.Models.Products;

namespace RestaurantFrontend.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ProductDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index(Guid Id)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/ProductById/{Id}");
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        ProductDetails Products = JsonConvert.DeserializeObject<ProductDetails>(responseBody);

                        if (Products != null)
                        {
                            return View(Products);
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
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

            }


            //var productDetails = GetSampleProductDetails();
            //return View(productDetails);
        }

        public IActionResult Details()
        {
            return View();
        }

        public static List<ProductDetails> GetSampleProductDetails()
        {
            var productDetails = new List<ProductDetails>
            {
                new ProductDetails
                {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Vegetables",
                    Name = "Greenhouse Cucumber - 1lb",
                    Image = "./images/Greenhouse_Cucumber.png",
                    SKU = "SKU123",
                    Price = 120,
                    ProductInfo = "High-end smartphone with advanced features.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Delivered",

                },
                };

            return productDetails;
        }
    }
}
