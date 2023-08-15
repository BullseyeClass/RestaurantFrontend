namespace RestaurantFrontend.Models.Order
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Category { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string SKU { get; set; }
        public string ProductInfo { get; set; }
        public string ReturnPolicy { get; set; }
        public string DeliveryInfo { get; set; }
        public string ShippingInfo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Guid CustomerId { get; set; }
    }
}
