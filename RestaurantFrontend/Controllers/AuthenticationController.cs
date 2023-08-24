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
using System.Net.Http.Headers;

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
                try
                {
                    var json = JsonConvert.SerializeObject(login);
                    var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{_baseUrl}/api/Authentication/login", requestBody);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                        if (apiResponse.Success)
                        {
                            string token = apiResponse.Data.Token;
                            string fullName = apiResponse.Data.FullName.ToString();
                            string userId = apiResponse.Data.Id;
                            string email = apiResponse.Data.Email;

                            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                            // Decode the JWT token to access its claims, including expiration
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var jwtToken = tokenHandler.ReadJwtToken(token);

                            // Extract the expiration from the JWT token
                            var expiration = jwtToken.ValidTo;
                            var tokenLifetime = (int)(expiration - DateTime.UtcNow).TotalSeconds;
                            var expirationTime = DateTimeOffset.UtcNow.AddSeconds(tokenLifetime);

                            // Save the token in an HttpOnly cookie
                            Response.Cookies.Append("token", token, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict,
                            });

                            
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, userId),
                                new Claim(ClaimTypes.Name, fullName),
                                new Claim(ClaimTypes.Email, email)
                                // Add other claims as needed
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProperties = new AuthenticationProperties
                            {
                                ExpiresUtc = expirationTime 
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);

                            TempData["SuccessMessage"] = apiResponse.Message;

                            string returnUrl = TempData["ReturnUrl"] as string;
                            if (returnUrl != null)
                            {
                                return Redirect(string.IsNullOrEmpty(returnUrl) ? "/default" : returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            TempData["ErrorMessage"] = apiResponse.Message;
                            return RedirectToAction("RegistrationPage", "Registration");
                        }
                    }
                    else
                    {
                        // Handle HTTP request error (e.g., display an error message)
                        TempData["ErrorMessage"] = "Invalid Credentials";
                        return RedirectToAction("RegistrationPage", "Registration");
                    }

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ErrorMessage");
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
                        TempData["ErrorMessage"] = "Email Already Exist";
                        //return View();
                        return RedirectToAction("RegistrationPage", "Registration");

                    }
                }
            }
            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add this attribute for security against cross-site request forgery (CSRF) attacks.
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
