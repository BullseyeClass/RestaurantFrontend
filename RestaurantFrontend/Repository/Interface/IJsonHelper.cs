using RestaurantFrontend.Models.Error404;
using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Policy;
using RestaurantFrontend.Models.Products;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelper
    {
        string GetPath(string fileName);
        List<Products> ReadFromJsons(string fullPath);


        List<MostPopularItem> ReadFromJsonsMostPopular(string fullPath);


        List<PolicyAndTerms> ReadFromJsonsPolicy(string fullPath);
    }
}
