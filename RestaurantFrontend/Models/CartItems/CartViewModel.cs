namespace RestaurantFrontend.Models.CartItems
{
    public class CartViewModel
    {
        public Guid id { get; set; }
        public string category { get; set; }
        public string tag { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string sKU { get; set; }
        public double price { get; set; }
        public float discountedPrice { get; set; }
        public int quantityInStock { get; set; }
        public string productInfo { get; set; }
        public string returnPolicy { get; set; }
        public string seliveryInfo { get; set; }
        public string thippingInfo { get; set; }
        public string quantity { get; set; }
    }
}
