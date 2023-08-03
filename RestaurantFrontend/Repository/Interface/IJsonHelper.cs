using RestaurantFrontend.Models;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelper
    {
        string GetPath(string fileName);
        List<MostPopularItem> ReadFromJsons(string fullPath);
    }
}
