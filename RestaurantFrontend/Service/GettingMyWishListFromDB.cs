using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Service
{
    public class GettingMyWishListFromDB : IGettingMyWishList
    {
        private readonly IJsonHelperMWL _jsonHelperMWL;
        private readonly IHostEnvironment _env;

        public GettingMyWishListFromDB(IJsonHelperMWL jsonHelperMWL, IHostEnvironment hostEnvironment)
        {
            _jsonHelperMWL = jsonHelperMWL;
            _env = hostEnvironment;
        }

        public IEnumerable<MyWishList> GetMyWishListFromDataSource()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Data", "Product.json");
            return _jsonHelperMWL.ReadFromJsons(filePath);
        }
    }
}
