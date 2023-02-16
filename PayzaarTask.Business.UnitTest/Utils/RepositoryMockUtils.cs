using PayzaarTask.Infrastructure;
using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;

namespace PayzaarTask.Business.UnitTest.Utils
{
    public class RepositoryMockUtils
    {
        // Setup to mock the repository to unit test the business layer inpendently of the infrastucture layer
        public List<Product> GetAllProductsMock()
        {
            return new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = ProductType.AllDay },
                new Product { ProductName = "Breakfast Burrito", ProductType = ProductType.Limited, StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = ProductType.Limited, StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = ProductType.Limited, StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = ProductType.Limited, StartHour = 17, EndHour = 23 }
            };
        }
    }
}
