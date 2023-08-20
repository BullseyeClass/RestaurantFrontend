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
                };

            return productDetails;
        }
    }
}
