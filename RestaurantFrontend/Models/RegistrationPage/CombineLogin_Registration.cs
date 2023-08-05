namespace RestaurantFrontend.Models.RegistrationPage
{
    public class CombineLogin_Registration
    {

        public Login Login { get; set; } = new Login();
        public Registration Registration { get; set; } = new Registration();
    }
}
