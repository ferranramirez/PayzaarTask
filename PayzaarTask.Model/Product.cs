using System;

namespace PayzaarTask.Infrastructure.Model
{
    // Normally we would make a DTO/model for each layer, but in this case I decided to use the same since it is the same
    // and to simplify the code and avoid make some useless mappings
    public class Product : IEquatable<Product>
    {
        public string ProductName;
        public ProductType ProductType;
        public int StartHour, EndHour;

        // With the IEquatable interface we can compare the Product objects in the tests
        public bool Equals(Product obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Product item))
            {
                return false;
            }

            return this.ProductName.Equals(item.ProductName)
                && this.ProductType.Equals(item.ProductType)
                && this.StartHour == item.StartHour
                && this.EndHour == item.EndHour;
        }
    }
}
