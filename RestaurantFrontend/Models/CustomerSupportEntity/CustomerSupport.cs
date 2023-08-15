//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace RestaurantFrontend.Models.CustomerSupportEntity
{
    public class CustomerSupport
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
