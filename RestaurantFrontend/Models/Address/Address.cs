﻿namespace RestaurantFrontend.Models.Address
{
    public class Address 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int PostalCode { get; set; } = 0;
        public string Country { get; set; } = string.Empty;
        //public virtual Customer Customer { get; set; } = new Customer();
        public Guid CustomerId { get; set; }

        // Add a bool property to signify whether this address is a shipping address
        public bool IsShippingAddress { get; set; }
    }

}
