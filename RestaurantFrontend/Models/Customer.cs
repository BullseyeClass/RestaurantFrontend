namespace RestaurantFrontend.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
