namespace RestaurantFrontend.Models
{
    public class MostPopularItem
    {
        public int id { get; set; }
        public string category { get; set; }
        public string tag { get; set; }
        public string productName { get; set; }
        public string image { get; set; }
        public string SKU { get; set; }
        public bool mostPopular { get; set; }
        public bool bestDeal { get; set; }
        public string price { get; set; }
        public string discountedPrice { get; set; }
        public string productInfo { get; set; }
        public string returnPolicy { get; set; }
        public string shippingInfo { get; set; }


    }
}
