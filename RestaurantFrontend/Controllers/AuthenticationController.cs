using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantFrontend.Models;
using RestaurantFrontend.Models.RegistrationPage;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Net.Http;
using RestaurantFrontend.Models.ApiResponses;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> Login(Login login)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(login);
                var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{_baseUrl}/api/Authentication/login", requestBody);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                    // Ensure the API response indicates success
                    if (apiResponse.Success)
                    {
                        string token = apiResponse.Data.Token;
                        string fullName = apiResponse.Data.FullName.ToString();

                        // Decode the JWT token to access its claims, including expiration
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var jwtToken = tokenHandler.ReadJwtToken(token);

                        // Extract the expiration from the JWT token
                        var expiration = jwtToken.ValidTo;

                        var tokenLifetime = (int)(expiration - DateTime.UtcNow).TotalSeconds;

                        // Save the token in an HttpOnly cookie
                        Response.Cookies.Append("token", token, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Strict,
                            MaxAge = TimeSpan.FromSeconds(tokenLifetime)// Set the cookie expiration based on the JWT token's expiration
                        });

                        // Create claims for the user
                        var claims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name, login.Email),
                    new Claim(ClaimTypes.Name, fullName)
                    // Add other claims as needed
                };

                        // Create an identity and principal
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        // Sign in the user
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // Redirect to the dashboard or home page upon successful login
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Handle unsuccessful login (e.g., display an error message)
                        ViewBag.ErrorMessage = apiResponse.Message;
                        return RedirectToAction("RegistrationPage", "Registration");
                    }
                }
                else
                {
                    // Handle HTTP request error (e.g., display an error message)
                    ViewBag.ErrorMessage = "An error occurred while processing your request.";
                    return RedirectToAction("RegistrationPage", "Registration");
                }
            }
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
                        return RedirectToAction("RegistrationPage", "Registration");

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

        [HttpPost]
        [ValidateAntiForgeryToken] // Add this attribute for security against cross-site request forgery (CSRF) attacks.
        public async Task<IActionResult> Logout()
        {
            // Sign out the current user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the home page or any other page after logout
            return RedirectToAction("Index", "Home");
        }
    }
}
