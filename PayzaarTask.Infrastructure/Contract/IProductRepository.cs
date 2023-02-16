using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;

namespace PayzaarTask.Infrastructure.Contract
{
    public interface IProductRepository
    {
        // We create interfaces to apply the Liskov principle, so out code doesn't rely on a specific implementation
        IEnumerable<Product> GetAllProducts();
    }
}