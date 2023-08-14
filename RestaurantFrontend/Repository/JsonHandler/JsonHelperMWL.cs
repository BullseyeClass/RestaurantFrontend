using RestaurantFrontend.Models;
using RestaurantFrontend.Models.MyWishListPage;
using RestaurantFrontend.Repository.Interface;
using System.Text.Json;

namespace RestaurantFrontend.Repository.JsonHandler
{
    public class JsonHelperMWL:IJsonHelperMWL
    {
        public string GetPath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            string dbFolderPath = Path.GetFullPath(Path.Combine(currentDir, @"Data"));
            string filePath = Path.Combine(dbFolderPath, fileName);
            return filePath;
        }

        public List<MyWishList> ReadFromJsons(string fullPath)
        {
            fullPath = GetPath("Product.json");
            string jsonContent = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<List<MyWishList>>(jsonContent);
        }
    }
}
