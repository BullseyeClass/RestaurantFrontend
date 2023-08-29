namespace RestaurantFrontend.Models.ApiResponses
{
    public class UserAddress
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string CustomerId { get; set; }
        public bool IsShippingAddress { get; set; }
    }

    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<UserAddress> Addresses { get; set; }
    }

}
