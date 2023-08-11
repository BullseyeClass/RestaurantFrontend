using RestaurantFrontend.Models.Products;
using RestaurantFrontend.Repository.Interface;
using System.Text.Json;

namespace RestaurantFrontend.Repository.JsonHandler
{
    public class JsonHelper : IJsonHelper
    {
        public string GetPath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            string dbFolderPath = Path.GetFullPath(Path.Combine(currentDir, @"DB"));
            string filePath = Path.Combine(dbFolderPath, fileName);
            return filePath;
        }

        public List<Products> ReadFromJsons(string fullPath)
        {
            fullPath = GetPath("product.json");
            string jsonContent = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<List<Products>>(jsonContent);
        }
    }
}

