using RestaurantFrontend.Models.MostPopularProducts;
using RestaurantFrontend.Models.Policy;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IGettingPolicyFromDB
    {
        IEnumerable<PolicyAndTerms> GettingPolicyFromDBs();
    }
}
