using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Address;
using RestaurantFrontend.Models.ApiResponses;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Models.RegistrationPage;
using RestaurantFrontend.Service;
using System.Security.Claims;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(TokenExpirationFilter))]
    public class AddressController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public AddressController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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
                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/Address/GetAllAddress");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Address> allAddress = JsonConvert.DeserializeObject<List<Address>>(responseBody);

                        var UserAddress = allAddress.Where(x => x.CustomerId == Guid.Parse(userId));

                        string errorMessage = TempData["SuccessMessage"] as string;

                        ViewBag.SuccessMessage = errorMessage;

                        return View(UserAddress);

                    }

                    else
                    {
                        //Handle error case
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                }
                catch (Exception ex)
                {
                    
                }
                return RedirectToAction("Index", "ErrorMessage");


            }
        }

        public async Task<IActionResult> DeleteAddress(Guid Id)
        {

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"{_baseUrl}/api/Address/DeleteAddress/{Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        TempData["SuccessMessage"] = responseData;
                        return RedirectToAction("Index", "Address");

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
        public async Task<IActionResult> CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address address)
        {

            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        if (HttpContext.Request.Cookies.TryGetValue("token", out string token))
                        {
                            // Use the "token" value as needed
                            var json = JsonConvert.SerializeObject(address);
                            var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                            var response = await httpClient.PostAsync($"{_baseUrl}/api/Address/AddAddress", requestBody);
                            if (response.IsSuccessStatusCode)
                            {
                                var responseData = await response.Content.ReadAsStringAsync();
                                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                                //var responseBody = await response.Content.ReadAsStringAsync();

                                TempData["SuccessMessage"] = apiResponse.Message;
                                return RedirectToAction("Index", "Address");

                            }
                            else
                            {
                                // Handle error case
                                return RedirectToAction("Index", "ErrorMessage");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                    
                }
            }
            return View(address);
        }


        [HttpGet]
        public async Task<IActionResult> EditAddress(Guid Id)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync($"{_baseUrl}/api/Address/GetAddressById/{Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var address = JsonConvert.DeserializeObject<Address>(responseBody);

                        return View(address);

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





        [HttpPost]
        public async Task<IActionResult> EditAddress(Address address)
        {

            if (ModelState.IsValid)
            {
                
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        if (HttpContext.Request.Cookies.TryGetValue("token", out string token))
                        {
                            var json = JsonConvert.SerializeObject(address);
                            var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                            var response = await httpClient.PutAsync($"{_baseUrl}/api/Address/UpdateAddress/{address.Id}", requestBody);


                            if (response.IsSuccessStatusCode)
                            {
                                var responseData = await response.Content.ReadAsStringAsync();

                                TempData["SuccessMessage"] = responseData;
                                return RedirectToAction("Index", "Address");

                            }
                            else
                            {
                                // Handle error case
                                return View();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "ErrorMessage");
                    }
                    

                    
                }
            }
            return View(address);
        }


    }

}