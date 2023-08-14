using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MyWishListPage;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IGettingMyWishList
    {
        IEnumerable<MyWishList> GetMyWishListFromDataSource();
    }
}
