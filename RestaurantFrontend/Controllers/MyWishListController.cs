using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.ApiResponses;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Models.Products;
using System.Security.Claims;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    public class MyWishListController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public MyWishListController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        [Route("AddWishList")]
        public async Task<IActionResult> AddToWishlist(Guid Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Generate the return URL with query parameters
                var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

                return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });
            }


            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (HttpContext.Request.Cookies.TryGetValue("token", out string token))
                    {

                        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                        var response = await httpClient.PostAsync($"{_baseUrl}/api/WishList/AddWishList/{Id}", null);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                           

                            TempData["SuccessMessage"] = responseData;
                            return RedirectToAction("WishLists", "MyWishList");

                        }
                        else
                        {

                            return RedirectToAction("Index", "ErrorMessage");

                        }
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


        [HttpGet]
        [Route("WishLists")]
        public async Task<IActionResult> WishLists()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Generate the return URL with query parameters
                var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

                return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });
            }

            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/WishList/AllWishList");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<WishList> allWishList = JsonConvert.DeserializeObject<List<WishList>>(responseBody);

                        var userWishList = allWishList.Where(x => x.CustomerId == Guid.Parse(userId)).ToList();

                        if (userWishList.Count > 0)
                        {
                            var productDetailsList = new List<Products>();
                            var combinedWishList = new CombinedWishList(); // Create an instance of CombinedWishList

                            foreach (var wishlistItem in allWishList)
                            {
                                try
                                {
                                    var newresponse = await httpClient.GetAsync($"{_baseUrl}/GetAllProductIDs?guids={wishlistItem.ProductId}");

                                    if (newresponse.IsSuccessStatusCode)
                                    {
                                        var responseData = await newresponse.Content.ReadAsStringAsync();
                                        var productDetails = JsonConvert.DeserializeObject<List<Products>>(responseData);
                                        productDetailsList.AddRange(productDetails);

                                        // Populate WishListItems in CombinedWishList
                                        combinedWishList.WishListItems = userWishList;
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

                            // Populate ProductItems in CombinedWishList
                            combinedWishList.ProductItems = productDetailsList;

                            string sucessMessage = TempData["SuccessMessage"] as string;
                            ViewBag.SuccessMessage = sucessMessage;

                            return View(combinedWishList);
                        }
                        else
                        {
                            return View(new CombinedWishList()); // Pass an empty CombinedWishList instance
                        }
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


        public async Task<IActionResult> DeleteWishList(Guid Id)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"{_baseUrl}/api/WishList/DeleteWishList/{Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        TempData["SuccessMessage"] = responseData;
                        return RedirectToAction("WishLists", "MyWishList");

                    }
                    else
                    {

                        return View();

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
