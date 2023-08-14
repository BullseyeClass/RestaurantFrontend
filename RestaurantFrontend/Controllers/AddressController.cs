using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.Address;

namespace RestaurantFrontend.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            // Simulate getting addresses from a database or other source
            var addresses = GetSampleAddresses();

            return View(addresses);
        }

        public static List<Address> GetSampleAddresses()
        {
            // Simulate sample data
            var addresses = new List<Address>
            {
                new Address
                {
                    Street = "123 Main St",
                    City = "Cityville",
                    State = "State",
                    PostalCode = 12345,
                    Country = "Country",
                    IsShippingAddress = true
                },
                new Address
                {
                    Street = "456 Elm St",
                    City = "Townville",
                    State = "State",
                    PostalCode = 67890,
                    Country = "Country",
                    IsShippingAddress = false
                },
                new Address
                {
                    Street = "456 Elm St",
                    City = "Townville",
                    State = "State",
                    PostalCode = 67890,
                    Country = "Country",
                    IsShippingAddress = true
                },
                 new Address
                {
                    Street = "123 Main St",
                    City = "Cityville",
                    State = "State",
                    PostalCode = 12345,
                    Country = "Country",
                    IsShippingAddress = true
                },
                new Address
                {
                    Street = "456 Elm St",
                    City = "Townville",
                    State = "State",
                    PostalCode = 67890,
                    Country = "Country",
                    IsShippingAddress = false
                },
                new Address
                {
                    Street = "789 Oak Ave",
                    City = "Villageville",
                    State = "State",
                    PostalCode = 54321,
                    Country = "Country",
                    IsShippingAddress = true
                },
                new Address
                {
                    Street = "101 Pine Rd",
                    City = "Townsville",
                    State = "State",
                    PostalCode = 98765,
                    Country = "Country",
                    IsShippingAddress = true
                },
                 new Address
                {
                    Street = "789 Oak Ave",
                    City = "Villageville",
                    State = "State",
                    PostalCode = 54321,
                    Country = "Country",
                    IsShippingAddress = true
                }
                };

            return addresses;
        }
    }
}
