using NuGet.Packaging.Signing;
using RestaurantFrontend.Models;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IGettingMostPopularItem
    {
        IEnumerable<MostPopularItem> GetMostPopularItemFromDataSource();
    }
}
