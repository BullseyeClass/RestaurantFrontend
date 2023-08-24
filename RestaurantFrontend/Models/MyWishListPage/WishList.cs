namespace RestaurantFrontend.Models.MyWishListPage
{
    public class WishList
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
