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
        [Route("VegetablesMC")]
        public IActionResult Vegetables()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Vegetables");

            return View("Product", products);
        }


        [Route("Vegetables/Deals")]
        public IActionResult VegetablesDeals()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Vegetables" && x.BestDeal);

            return View("Product", products);
        }


        [Route("FruitsMC")]
        public IActionResult Fruits()
        {
            var product = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fruit");

            return View("Product", product);
        }

        [Route("Meat & PoultryMC")]
        public IActionResult Meat_Poultry()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Meat & Poultry");

            return View("Product", products);
        }

        [Route("Fish & SeafoodMC")]
        public IActionResult Fish_Seafood()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Fish & Seafood"); 

            return View("Product", products);
        }

        [Route("Dairy & EggsMC")]
        public IActionResult Dairy_Eggs()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Dairy & Eggs");

            return View("Product", products);
        }

        [Route("BakeryMC")]
        public IActionResult Bakery()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Bakery");

            return View("Product", products);
        }

        [Route("Pastas_GrainsMC")]
        public IActionResult Pastas_Grains()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Dairy & Eggs");

            return View("Product", products);
        }

        [Route("Cereals_SnacksMC")]
        public IActionResult Cereals_Snacks()
        {
            var products = _gettingProductsFromDB.GetProductsFromDataSource().Where(x => x.Tag == "Bakery");

            return View("Product", products);
        }



    }
}
