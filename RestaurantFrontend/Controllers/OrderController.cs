using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestaurantFrontend.Models.CartItems;
using RestaurantFrontend.Models.Order;
using System.Net;
using System.Text.Json;
using System.Web;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly string _baseUrl;

        public OrderController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        [Route("Order")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Generate the return URL with query parameters
                var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

                return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });
            }

            string errorMessage = TempData["SuccessMessage"] as string;
            ViewBag.SuccessMessage = errorMessage;

            var orders = GetSampleOrders();
            return View(orders);
        }



        [Route("NewOrder")]
        public async Task<IActionResult> NewOrder(string? totalAmount, bool IsPayOnDelivery = false)
        {
            if (!User.Identity.IsAuthenticated)
            {
                
                var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

                return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });

            }
            try
            {
                if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
                {
                    using (var httpClient = new HttpClient())
                    {
                        var jsonData = new
                        {
                            TotalAmount = totalAmount,
                            Items = cartItems
                        };

                        var queryString = string.Join("&", JsonConvert.SerializeObject(jsonData)
                            .Split(',')
                            .Select(kv => HttpUtility.UrlEncode(kv.Trim()))
                        );
                        //generic post to order API
                        HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/PostToOrder?{queryString}");

                        if (response.IsSuccessStatusCode)
                        {

                            
                            string content = await response.Content.ReadAsStringAsync();

                            if (Guid.TryParse(content, out Guid resultGuid))
                            {
                                if (IsPayOnDelivery == true)
                                {
                                    //to be implemented
                                    _memoryCache.Remove("CartItems");
                                    return Ok("Order created successfully.");
                                }
                                else if (IsPayOnDelivery == false)
                                {
                                    //generic paystack API
                                    HttpResponseMessage paystack = await httpClient.GetAsync($"{_baseUrl}/api/Paystack?{queryString}");
                                    if (paystack.IsSuccessStatusCode)
                                    {
                                       //to be implemented
                                             _memoryCache.Remove("CartItems");
                                        return Ok("Order created successfully.");
                                    }
                                    else
                                    {
                                        return BadRequest("Payment failed.");
                                    }
                                }
                                else
                                {
                                    return BadRequest("An error occured");
                                }
                          
                            }
                            else
                            {
                                return BadRequest("Failed to parse response as Guid.");
                            }
                        }
                        else
                        {
                            
                            return BadRequest("Failed to retrieve product IDs.");
                        }
                    }
                }
                else
                {
                    return BadRequest("Cart items not found in cache.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return RedirectToAction("Index", "ErrorMessage");
            }

        }




        public static List<Order> GetSampleOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Vegetables",
                    Name = "Greenhouse Cucumber - 1lb",
                    Image = "./images/Greenhouse_Cucumber.png",
                    SKU = "SKU123",
                    ProductInfo = "High-end smartphone with advanced features.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Delivered",
                    OrderDate = DateTime.Now,
                    TotalAmount = 799.99m,
                    CustomerId = Guid.NewGuid()
                },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Vegetables",
                    Name = "Red Greenhouse Bell Pepper - 1lb",
                    Image =  "./images/Red_Greenhouse_Bell_Pepper.png",
                    SKU = "SKU456",
                    ProductInfo = "Comfortable cotton t-shirt with trendy design.",
                    ReturnPolicy = "15-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Pending",
                    OrderDate = DateTime.Now,
                    TotalAmount = 29.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                   Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag ="Fruit",
                    Name = "Banana Bunch - 1lb",
                    Image = "./images/Banana_Bunch.png",
                    SKU = "SKU789",
                    ProductInfo = "Energy-efficient refrigerator with spacious compartments.",
                    ReturnPolicy = "45-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 899.99m,
                    CustomerId = Guid.NewGuid()

                },
                 new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Meat & Poultry",
                    Name ="Steak A-La-Minute - 1lb",
                    Image =  "./images/Steak_A-La-Minute.png",
                    SKU = "SKU101",
                    ProductInfo = "Bestselling fiction novel with captivating story.",
                    ReturnPolicy = "60-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 19.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category =  "Food",
                    Tag = "Fish & Seafood",
                    Name ="Wild Domestic Shrimps - 1lb",
                    Image =  "./images/Wild_Domestic_Shrimps.png",
                    SKU = "SKU202",
                    ProductInfo = "High-quality yoga mat for comfortable workout sessions.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Delivered",
                    OrderDate = DateTime.Now,
                    TotalAmount = 39.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag ="Fish & Seafood",
                    Name ="Tuna Steak Fillet - 1lb",
                    Image =  "./images/Tuna_Steak_Fillet.png",
                    SKU = "SKU202",
                    ProductInfo = "High-quality yoga mat for comfortable workout sessions.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 39.99m,
                    CustomerId = Guid.NewGuid()
               },
                };

            return orders;
        }
    }
}
