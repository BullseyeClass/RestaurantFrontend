using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.RegistrationPage;

namespace RestaurantFrontend.Controllers.RegistrationPage
{
    public class RegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public RegistrationController(IConfiguration configuration)
        {
            this._configuration = configuration;
            _baseUrl = _configuration["AppSettings:BaseUrl"];
        }




        [Route("Registration")]
        public ActionResult RegistrationPage(string returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            // Access the TempData value and cast it to a string
            string errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisteringUser(Registration registrationViewModel)
        {
            using (var httpClient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(registrationViewModel);
                var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{_baseUrl}/api/Customer/register", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    // Process the response from the API

                    
                    return RedirectToAction("RegistrationPage", "Registration");

                }
                else
                {
                    // Handle error case
                    return View();

                }
            }
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }
    

    }

}

