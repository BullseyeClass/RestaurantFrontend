using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using RestaurantFrontend.Models.CartItems;

public class BaseController : Controller
{
    private readonly IMemoryCache _memoryCache;

    public BaseController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        int totalCartQuantity = CalculateTotalCartQuantity();
        ViewBag.TotalCartQuantity = totalCartQuantity;
        TempData["J"] = 5;
    }

    protected int CalculateTotalCartQuantity()
    {
        if (_memoryCache.TryGetValue("CartItems", out List<CartItem> cartItems))
        {
            int totalQuantity = cartItems.Sum(item => item.Quantity);
            return totalQuantity;
        }

        return 0;
    }
}
