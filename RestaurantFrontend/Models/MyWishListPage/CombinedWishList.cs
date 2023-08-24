//using RestaurantFrontend.Models.Products;
namespace RestaurantFrontend.Models.MyWishListPage
{
    public class CombinedWishList
    {
        public IEnumerable<RestaurantFrontend.Models.Products.Products> ProductItems { get; set; }
        public IEnumerable<WishList> WishListItems { get; set; }
    }
}
