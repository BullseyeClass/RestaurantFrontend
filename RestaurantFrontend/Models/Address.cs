﻿namespace RestaurantFrontend.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Customer Customer { get; set; }
    }
}
