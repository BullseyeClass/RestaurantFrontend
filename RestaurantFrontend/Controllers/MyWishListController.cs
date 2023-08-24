using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using RestaurantFrontend.Models.Address;
using RestaurantFrontend.Models.ApiResponses;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Models.ProductDetails;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Service;

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
                            //var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                            //var responseBody = await response.Content.ReadAsStringAsync();

                            //TempData["SuccessMessage"] = apiResponse.Message;
                            return RedirectToAction("WishLists", "MyWishList");

                        }
                        else
                        {
                            // Handle error case
                            return View();

                        }
                    }

                    else
                    {
                        //Handle error case
                        return View();
                    }


                    //HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/WishList/AddWishList/{Id}");
                    ////response.EnsureSuccessStatusCode();
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    string responseBody = await response.Content.ReadAsStringAsync();
                    //    ProductDetails Products = JsonConvert.DeserializeObject<ProductDetails>(responseBody);

                    //    if (Products != null)
                    //    {
                    //        return View(Products);
                    //    }

                    //    else
                    //    {
                    //        return RedirectToAction("EmptyProduct", "Products");
                    //    }


                    //}

                    //else
                    //{
                    //    //Handle error case
                    //    return View();
                    //}

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
                }

                //    var myWishList = _gettingMyWishListFromDB.GetMyWishListFromDataSource();
                //return View(myWishList.ToList());
            }


        }

        //[HttpGet]
        //[Route("WishList")]
        //public async Task<IActionResult> WishLists()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        // Generate the return URL with query parameters
        //        var returnUrl = Url.Action("Index", "Order", null, Request.Scheme) + Request.QueryString;

        //        return RedirectToAction("RegistrationPage", "Registration", new { returnUrl });
        //    }



        //    using (var httpClient = new HttpClient())
        //    {
        //        try
        //        {

        //            HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/WishList/AllWishList");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string responseBody = await response.Content.ReadAsStringAsync();
        //                List<WishList> allWishList = JsonConvert.DeserializeObject<List<WishList>>(responseBody);

        //                if (allWishList.Count > 0)
        //                {
        //                    var productDetailsList = new List<Products>();

        //                    foreach (var wishlistItem in allWishList)
        //                    {
        //                        try
        //                        {
        //                            // Make a GET request to retrieve product details based on productId
        //                            var newresponse = await httpClient.GetAsync($"{_baseUrl}/GetAllProductIDs?guids={wishlistItem.ProductId}");

        //                            if (newresponse.IsSuccessStatusCode)
        //                            {
        //                                var responseData = await newresponse.Content.ReadAsStringAsync();
        //                                //var productDetails = JsonConvert.DeserializeObject<Products>(responseData);
        //                                var productDetails = JsonConvert.DeserializeObject<List<Products>>(responseData);
        //                                productDetailsList.AddRange(productDetails);

        //                                //return View(productDetailsList);
        //                            }
        //                            else
        //                            {
        //                                // Handle error case for a specific productId
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            // Handle exception
        //                        }

        //                    }
        //                    return View(productDetailsList);

        //                }


        //                string errorMessage = TempData["SuccessMessage"] as string;

        //                ViewBag.SuccessMessage = errorMessage;

        //                return View(allWishList);

        //            }

        //            else
        //            {
        //                //Handle error case
        //                return View();
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            return RedirectToAction("Index", "ErrorMessage");
        //        }

        //        //var myWishList = _gettingMyWishListFromDB.GetMyWishListFromDataSource();
        //        //return View(myWishList.ToList());
        //    }

        //}

        [HttpGet]
        [Route("WishList")]
        public async Task<IActionResult> WishLists()
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
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/WishList/AllWishList");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<WishList> allWishList = JsonConvert.DeserializeObject<List<WishList>>(responseBody);

                        if (allWishList.Count > 0)
                        {
                            var productDetailsList = new List<Products>();
                            var combinedWishList = new CombinedWishList(); // Create an instance of CombinedWishList

                            foreach (var wishlistItem in allWishList)
                            {
                                try
                                {
                                    // Make a GET request to retrieve product details based on productId
                                    var newresponse = await httpClient.GetAsync($"{_baseUrl}/GetAllProductIDs?guids={wishlistItem.ProductId}");

                                    if (newresponse.IsSuccessStatusCode)
                                    {
                                        var responseData = await newresponse.Content.ReadAsStringAsync();
                                        var productDetails = JsonConvert.DeserializeObject<List<Products>>(responseData);
                                        productDetailsList.AddRange(productDetails);

                                        // Populate WishListItems in CombinedWishList
                                        combinedWishList.WishListItems = allWishList;
                                    }
                                    else
                                    {
                                        // Handle error case for a specific productId
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Handle exception
                                }

                            }

                            // Populate ProductItems in CombinedWishList
                            combinedWishList.ProductItems = productDetailsList;

                            // Pass the CombinedWishList instance to the View
                            return View(combinedWishList);
                        }
                        else
                        {
                            // Handle error case
                            return View(new CombinedWishList()); // Pass an empty CombinedWishList instance
                        }

                        string errorMessage = TempData["SuccessMessage"] as string;
                        ViewBag.SuccessMessage = errorMessage;
                        return View(allWishList);
                    }
                    else
                    {
                        // Handle error case
                        return View();
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

                var response = await httpClient.DeleteAsync($"{_baseUrl}/api/WishList/DeleteWishList/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    TempData["SuccessMessage"] = responseData;
                    //return RedirectToAction("MyWishList", "MyWishList");
                    return RedirectToAction("WishLists", "MyWishList");

                }
                else
                {

                    return View();

                }

            }
        }
    }
}
