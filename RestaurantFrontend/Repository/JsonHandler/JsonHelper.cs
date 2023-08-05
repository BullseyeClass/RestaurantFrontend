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
//{
//    "id": 5,
//    "ImageURL": "http://dotnethow.net/images/movies/movie-5.jpeg",
//    "Description": "This is the Cold Soles movie description",
//    "Price": 39.50
//  },
//  {
//    "id": 6,
//    "ImageURL": "http://dotnethow.net/images/movies/movie-6.jpeg",
//    "Description": "This is the Cold Soles movie description",
//    "Price": 39.50
//  },

//  {
//    "id": 7,
//    "ImageURL": "http://dotnethow.net/images/movies/movie-7.jpeg",
//    "Description": "This is the Cold Soles movie description",
//    "Price": 39.50
//  },
//  {
//    "id": 8,
//    "ImageURL": "http://dotnethow.net/images/movies/movie-8.jpeg",
//    "Description": "This is the Cold Soles movie description",
//    "Price": 39.50
//  }