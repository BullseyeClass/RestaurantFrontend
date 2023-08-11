using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Service
{
    public class GettingProductsFromDB : IGettingProductsFromDB
    {
        private readonly IJsonHelper _jsonHelper;
        private readonly IHostEnvironment _env;

        public GettingProductsFromDB(IJsonHelper jsonHelper, IHostEnvironment hostEnvironment)
        {
            _jsonHelper = jsonHelper;
            _env = hostEnvironment;
        }

        public IEnumerable<Products> GetProductsFromDataSource()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "DB", "product.json");
            return _jsonHelper.ReadFromJsons(filePath);
        }
    }
}
