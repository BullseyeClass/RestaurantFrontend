//using NuGet.Packaging.Signing;
using RestaurantFrontend.Models.MostPopularProducts;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IGettingMostPopularItem
    {
        IEnumerable<MostPopularItem> GetMostPopularItemFromDataSource();
    }
}
