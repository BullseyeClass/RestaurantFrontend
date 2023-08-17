﻿using Microsoft.AspNetCore.Mvc;
using RestaurantFrontend.Models.Order;

namespace RestaurantFrontend.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var orders = GetSampleOrders();
            return View(orders);
        }

        public static List<Order> GetSampleOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Vegetables",
                    Name = "Greenhouse Cucumber - 1lb",
                    Image = "./images/Greenhouse_Cucumber.png",
                    SKU = "SKU123",
                    ProductInfo = "High-end smartphone with advanced features.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Delivered",
                    OrderDate = DateTime.Now,
                    TotalAmount = 799.99m,
                    CustomerId = Guid.NewGuid()
                },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Vegetables",
                    Name = "Red Greenhouse Bell Pepper - 1lb",
                    Image =  "./images/Red_Greenhouse_Bell_Pepper.png",
                    SKU = "SKU456",
                    ProductInfo = "Comfortable cotton t-shirt with trendy design.",
                    ReturnPolicy = "15-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Pending",
                    OrderDate = DateTime.Now,
                    TotalAmount = 29.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                   Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag ="Fruit",
                    Name = "Banana Bunch - 1lb",
                    Image = "./images/Banana_Bunch.png",
                    SKU = "SKU789",
                    ProductInfo = "Energy-efficient refrigerator with spacious compartments.",
                    ReturnPolicy = "45-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 899.99m,
                    CustomerId = Guid.NewGuid()

                },
                 new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag = "Meat & Poultry",
                    Name ="Steak A-La-Minute - 1lb",
                    Image =  "./images/Steak_A-La-Minute.png",
                    SKU = "SKU101",
                    ProductInfo = "Bestselling fiction novel with captivating story.",
                    ReturnPolicy = "60-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 19.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category =  "Food",
                    Tag = "Fish & Seafood",
                    Name ="Wild Domestic Shrimps - 1lb",
                    Image =  "./images/Wild_Domestic_Shrimps.png",
                    SKU = "SKU202",
                    ProductInfo = "High-quality yoga mat for comfortable workout sessions.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Delivered",
                    OrderDate = DateTime.Now,
                    TotalAmount = 39.99m,
                    CustomerId = Guid.NewGuid()
               },
                new Order
               {
                    Id = Guid.NewGuid(),
                    Category = "Food",
                    Tag ="Fish & Seafood",
                    Name ="Tuna Steak Fillet - 1lb",
                    Image =  "./images/Tuna_Steak_Fillet.png",
                    SKU = "SKU202",
                    ProductInfo = "High-quality yoga mat for comfortable workout sessions.",
                    ReturnPolicy = "30-day return policy.",
                    DeliveryInfo = "Delivered",
                    ShippingInfo = "Shipped",
                    OrderDate = DateTime.Now,
                    TotalAmount = 39.99m,
                    CustomerId = Guid.NewGuid()
               },
                };

            return orders;
        }
    }
}