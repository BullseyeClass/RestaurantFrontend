namespace RestaurantFrontend.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
