using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using RestaurantFrontend.Models.CartItems;
using RestaurantFrontend.Models.Products;
using System.Net;
using System.Text.Json;

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
                        ProductId = new Guid(productId),
                        Quantity = parsedQuantity
                    };

                    CartItem firstMatchingElement = cartItems.FirstOrDefault(item => item.ProductId == cartItem.ProductId);


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
        [Route("Checkout")]
        public async Task<IActionResult> DisplayCartItem()
        {
            //if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
            //{
            //    return Ok(cartItems);
            //}

            return View();
        }


        public async Task<IActionResult> RemoveFromCart(string productId, string quantity)
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
                        ProductId = new Guid(productId),
                        Quantity = parsedQuantity
                    };

                    CartItem firstMatchingElement = cartItems.FirstOrDefault(item => item.ProductId == cartItem.ProductId);


                    if (firstMatchingElement != null)
                    {
                        cartItems.Remove(firstMatchingElement);
                    }
                    else
                    {
                        return NotFound();
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

        [Route("GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
                    {
                        List<Guid> guids = cartItems.Select(item => item.ProductId).ToList();
                        string guidsQueryString = string.Join("&", guids.Select(g => $"guids={g}"));

                        HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/GetAllProductIDs?{guidsQueryString}");

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            List<CartViewModel> cartdeserailized = JsonSerializer.Deserialize<List<CartViewModel>>(content);

                            foreach (var cartIte in cartItems)
                            {
                                var matchedCartItem = cartdeserailized.FirstOrDefault(c => c.id == cartIte.ProductId);
                                if (matchedCartItem != null)
                                {
                                    matchedCartItem.quantity = cartIte.Quantity.ToString();
                                }
                            }
                            if(cartdeserailized != null)
                            {

                                return Json(cartdeserailized);
                            }
                        

                            
                        }
                        else
                        {
                            return BadRequest($"Request failed with status code: {response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

                return BadRequest();
            }
        }



    }

}



