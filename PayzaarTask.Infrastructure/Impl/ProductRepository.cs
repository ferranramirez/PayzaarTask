using PayzaarTask.Infrastructure.Contract;
using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;

namespace PayzaarTask.Infrastructure.Impl
{
    public class ProductRepository : IProductRepository
    {
        // We should move this data in an external DB so we could have real data 
        List<Product> productsDB = new List<Product>
        {
            new Product { ProductName = "Orange Juice", ProductType = ProductType.AllDay },
            new Product { ProductName = "Breakfast Burrito", ProductType = ProductType.Limited, StartHour = 8, EndHour = 12 },
            new Product { ProductName = "Steak & Chips", ProductType = ProductType.Limited, StartHour = 12, EndHour = 21 },
            new Product { ProductName = "Chicken Sandwich", ProductType = ProductType.Limited, StartHour = 11, EndHour = 19 },
            new Product { ProductName = "Sam Adams Seasonal", ProductType = ProductType.Limited, StartHour = 17, EndHour = 23 }
        };

        // Delivered this functionality to a Repository since all the product will come from a storage source and we don't want to give that responsibility
        // to the Business layer.
        public IEnumerable<Product> GetAllProducts()
        {
            return productsDB;
        }
    }
}
