using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MyWishListPage;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelperMWL
    {
        string GetPath(string fileName);
        List<MyWishList> ReadFromJsons(string fullPath);
    }
}
