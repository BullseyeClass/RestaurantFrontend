using NuGet.Packaging.Signing;
using RestaurantFrontend.Models;
using RestaurantFrontend.Repository.Interface;
using System.Text.Json;

namespace RestaurantFrontend.Repository.JsonHandler
{
    public class JsonHelper : IJsonHelper
    {
        public string GetPath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            string dbFolderPath = Path.GetFullPath(Path.Combine(currentDir, @"JsonFiles"));
            string filePath = Path.Combine(dbFolderPath, fileName);
            return filePath;
        }

        public List<MostPopularItem> ReadFromJsons(string fullPath)
        {
            fullPath = GetPath("data.json");
            string jsonContent = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<List<MostPopularItem>>(jsonContent);
        }


        //public List<PopularSectionItem> ReadFromJsonss(string fullPath)
        //{
        //    fullPath = GetPath("data.json");
        //    string jsonContent = File.ReadAllText(fullPath);
        //    return JsonSerializer.Deserialize<List<PopularSectionItem>>(jsonContent);
        //}

    }
}
