using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Policy;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelper
    {
        string GetPath(string fileName);
        List<MostPopularItem> ReadFromJsons(string fullPath);


        List<PolicyAndTerms> ReadFromJsonsPolicy(string fullPath);
    }
}
