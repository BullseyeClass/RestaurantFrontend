//using NuGet.Packaging.Signing;
using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Service
{
    public class GettingMostPopularItemFromDB : IGettingMostPopularItem
    {

        private readonly IJsonHelper _jsonHelper;
        private readonly IHostEnvironment _env;

        public GettingMostPopularItemFromDB(IJsonHelper jsonHelper, IHostEnvironment hostEnvironment)
        {
            _jsonHelper = jsonHelper;
            _env = hostEnvironment;
        }

        public IEnumerable<MostPopularItem> GetMostPopularItemFromDataSource()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "JsonFiles", "data.json");
            return _jsonHelper.ReadFromJsonsMostPopular(filePath);
        }
    }
}
