using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.ProductDetails;

namespace RestaurantFrontend.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index()
        {
            var productDetails = GetSampleProductDetails();
            return View(productDetails);
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

                new ProductDetails
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag ="Fish & Seafood",
                    Name ="Tuna Steak Fillet - 1lb",
                    Image =  "./images/Tuna_Steak_Fillet.png",
                    SKU = "SKU202",
                    Price = 500,
                    ProductInfo = "High-quality yoga mat for comfortable workout sessions.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    
               },
                };

            return productDetails;
        }
    }
}
