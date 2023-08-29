using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Address;
using RestaurantFrontend.Models.ApiResponses;
using System.Security.Claims;

namespace RestaurantFrontend.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public UserAccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Store the current URL in a session variable
                HttpContext.Session.SetString("ReturnUrl", Request.Path + Request.QueryString);
                return RedirectToAction("Login", "Authentication");
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

                    HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/Customer/FullUserDetails/{userId}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<UserDetails> userDetails = JsonConvert.DeserializeObject<List<UserDetails>>(responseBody);

                        //var UserAddress = allAddress.Where(x => x.CustomerId == Guid.Parse(userId));

                        //string errorMessage = TempData["SuccessMessage"] as string;

                        //ViewBag.SuccessMessage = errorMessage;

                        return View(userDetails);

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
    }
}
