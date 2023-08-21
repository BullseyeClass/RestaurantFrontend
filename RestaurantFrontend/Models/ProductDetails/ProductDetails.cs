namespace RestaurantFrontend.Models.ProductDetails
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string SKU { get; set; }
        public bool MostPopular { get; set; }
        public bool BestDeal { get; set; }
        public double Price { get; set; }
        public float DiscountedPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string ProductInfo { get; set; }
        public string ReturnPolicy { get; set; }
        public string DeliveryInfo { get; set; }
        public string ShippingInfo { get; set; }
    }
}
