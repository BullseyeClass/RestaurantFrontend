using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.RegistrationPage;
using System.Diagnostics;
using System.Reflection;

namespace RestaurantFrontend.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public AuthenticationController(IConfiguration configuration)
        {
            this._configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    
                    var json = JsonConvert.SerializeObject(registration);
                    var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{_baseUrl}/api/Customer/register", requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        // Process the response from the API
                        return View();

                    }
                    else
                    {
                        // Handle error case
                        return View();

                    }
                }
            }
            return View(registration); 
        }
    }
}
