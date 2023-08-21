using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using RestaurantFrontend.Models.CartItems;
using RestaurantFrontend.Models.Products;

namespace RestaurantFrontend.Controllers
{
    public class CartController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly string _baseUrl;

        public CartController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }




        public async Task<IActionResult> AddToCart(string productId, string quantity)
        {
            try
            {
                if (productId != null && int.TryParse(quantity, out int parsedQuantity) && parsedQuantity > 0)
                {
                    if (!_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
                    {
                        cartItems = new List<CartItem>();
                    }

                    var cartItem = new CartItem
                    {
                        Id = new Guid(productId),
                        Quantity = parsedQuantity
                    };

                    CartItem firstMatchingElement = cartItems.FirstOrDefault(item => item.Id == cartItem.Id);


                    if (firstMatchingElement != null)
                    {
                        firstMatchingElement.Quantity += cartItem.Quantity;
                    }
                    else
                    {
                        cartItems.Add(cartItem);
                    }


                    _memoryCache.Set("CartItems", cartItems);

                    CalculateTotalCartQuantity();

                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorMessage");
            }
        }
        [Route("CartDisplay")]
        public int CalculateTotalCartQuantity()
        {
            if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
            {
                int totalQuantity = cartItems.Sum(item => item.Quantity);
                return totalQuantity;
            }

            return 0;
        }

        public async Task<IActionResult> DisplayCartItem()
        {
            if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
            {
                return Ok(cartItems); 
            }

            return NotFound();
        }





    }

}





//        public async Task<ActionResult> AddToCart(string productId, string quantity)
//        {
//            //using (var httpClient = new HttpClient())
//            //{
//            try
//            {
//                //HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/ProductFilter/ProductById/{productId}");

//                if (productId != null && Parse(quantity) > 0)
//                {
//                    var product = await response.Content.ReadFromJsonAsync<Products>(); // Deserialize the product data

//                    var cartItems = new List<Products>(); // Create a list to store cart items

//                    for (int i = 0; i < Parse(quantity); i++)
//                    {
//                        var cartItem = new Products
//                        {
//                            Id = product.Id,
//                            Name = product.Name,
//                            Price = product.Price,
//                            QuantityInStock = product.QuantityInStock,
//                            Image = product.Image,
//                            DeliveryInfo = product.DeliveryInfo,
//                            DiscountedPrice = product.DiscountedPrice,
//                            SKU = product.SKU,
//                            ShippingInfo = product.ShippingInfo,
//                            ProductInfo = product.ProductInfo,
//                        };

//                        cartItems.Add(cartItem); // Add the cart item to the list
//                    }

//                    // Now you can do something with the cartItems list, like adding it to the user's cart

//                    return Json(new { success = true });
//                }

//                return Json(new { success = false });
//            }
//                catch (Exception ex)
//            {
//                return RedirectToAction("Index", "ErrorMessage");
//            }
//            //}
//        }

//        private int Parse(string quantity)
//        {
//            throw new NotImplementedException();
//        }
