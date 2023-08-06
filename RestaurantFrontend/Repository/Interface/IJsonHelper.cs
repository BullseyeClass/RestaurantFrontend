using RestaurantFrontend.Models.MostPopularProducts;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelper
    {
        string GetPath(string fileName);
        List<MostPopularItem> ReadFromJsons(string fullPath);

       // List<PopularSectionItem> ReadFromJsonss(string fullPath);
    }
}
