using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Repository.Interface;

namespace RestaurantFrontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGettingProductsFromDB _gettingProductsFromDB;

        public ProductsController(IGettingProductsFromDB gettingProductsFromDB)
        {
            _gettingProductsFromDB = gettingProductsFromDB;
        }
        [Route("Vegetables")]
        public IActionResult Vegetables()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }


  
        [Route("Fruits")]
        public IActionResult Fruits()
        {
            var product = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(product.ToList());
        }

        [Route("Meat_Poultry")]
        public IActionResult Meat_Poultry()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }

        [Route("Fish_Seafood")]
        public IActionResult Fish_Seafood()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }

        [Route("Dairy_Eggs")]
        public IActionResult Dairy_Eggs()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }

        [Route("Bakery")]
        public IActionResult Bakery()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }

        [Route("Pastas_Grains")]
        public IActionResult Pastas_Grains()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }

        [Route("Cereals_Snacks")]
        public IActionResult Cereals_Snacks()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource();

            return View(products.ToList());
        }






    }
}
