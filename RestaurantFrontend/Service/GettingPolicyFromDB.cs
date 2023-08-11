using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Policy;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Service
{
    public class GettingPolicyFromDB : IGettingPolicyFromDB
    {
        private readonly IJsonHelper _jsonHelper;
        private readonly IHostEnvironment _hostEnvironment;

        public GettingPolicyFromDB(IJsonHelper jsonHelper, IHostEnvironment hostEnvironment)
        {
            _jsonHelper = jsonHelper;
            _hostEnvironment = hostEnvironment;
        }

        public IEnumerable<PolicyAndTerms> GettingPolicyFromDBs()
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "JsonFiles", "data.json");
            return _jsonHelper.ReadFromJsonsPolicy(filePath);
        }
    }
}
