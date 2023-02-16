using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;

namespace PayzaarTask.Business.Contract
{
    // We create interfaces to apply the Liskov principle, so out code doesn't rely on a specific implementation
    public interface IProductService
    {
        IEnumerable<Product> ProductsAvailableNow { get; }

        IEnumerable<Product> ListAllProducts();
        void UpdateListOfAvailableProducts(int currentHour); // Add the 'currentHour' for testing purposes
    }
}