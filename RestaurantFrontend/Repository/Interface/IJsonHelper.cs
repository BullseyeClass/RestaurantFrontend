using RestaurantFrontend.Models.Products;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IJsonHelper
    {
        string GetPath(string fileName);
        List<Products> ReadFromJsons(string fullPath);
    }
}
