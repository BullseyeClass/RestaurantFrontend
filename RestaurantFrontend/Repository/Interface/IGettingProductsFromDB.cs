using RestaurantFrontend.Models.Products;
using System.Collections.Generic;

namespace RestaurantFrontend.Repository.Interface
{
    public interface IGettingProductsFromDB
    {
        IEnumerable<Products> GetProductsFromDataSource();
    }
}
