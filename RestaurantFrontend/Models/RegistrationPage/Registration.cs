using System.ComponentModel.DataAnnotations;

namespace RestaurantFrontend.Models.RegistrationPage
{
    public class Registration
    {
            [Required(ErrorMessage = "Username is required")]
            public string UserName { get; set; }
            
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            //[Required(ErrorMessage = "Confirm Password is required")]
            //[Compare("Password", ErrorMessage = "Passwords do not match")]
            //[DataType(DataType.Password)]
            //public string ConfirmPassword { get; set; }
        
    }
}
