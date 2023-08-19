using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantFrontend.Models.Address;
using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Models.RegistrationPage;

namespace RestaurantFrontend.Controllers
{
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
            using (var httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/api/Address/GetAllAddress");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Address> allAddress = JsonConvert.DeserializeObject<List<Address>>(responseBody);


                    return View(allAddress);

                }

                else
                {
                    //Handle error case
                    return View();
                }


            }
        }

        public async Task<IActionResult> DeleteAddress(Guid Id)
        {

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.DeleteAsync($"{_baseUrl}/api/Address/DeleteAddress/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    ViewBag.ResponseMessage = responseBody;
                    return RedirectToAction("Index", "Address");

                }
                else
                {

                    return View();

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

                    var json = JsonConvert.SerializeObject(address);
                    var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{_baseUrl}/api/Address/AddAddress", requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        // Process the response from the API
                        return RedirectToAction("Index", "Address");

                    }
                    else
                    {
                        // Handle error case
                        return View();

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
                    return View();
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

                    var json = JsonConvert.SerializeObject(address);
                    var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"{_baseUrl}/api/Address/UpdateAddress/{address.Id}", requestBody);


                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        // Process the response from the API
                        return RedirectToAction("Index", "Address");

                    }
                    else
                    {
                        // Handle error case
                        return View();

                    }
                }
            }
            return View(address);
        }


    }

}