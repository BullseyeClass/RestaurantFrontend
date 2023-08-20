using System.ComponentModel.DataAnnotations;

namespace RestaurantFrontend.Models.Address
{
    public class Address 
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required (ErrorMessage = "Street is required")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        public int PostalCode { get; set; } = 0;

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }

        // Add a bool property to signify whether this address is a shipping address
        public bool IsShippingAddress { get; set; }
    }

}
