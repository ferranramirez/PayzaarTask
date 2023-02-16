using PayzaarTask.Business.Contract;
using PayzaarTask.Infrastructure;
using PayzaarTask.Infrastructure.Contract;
using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;

namespace PayzaarTask.Business.Impl
{

    public class ProductService : IProductService
    {
        private IEnumerable<Product> _productsAvailableNow;

        // Commented since I'm not using different DTOs betweern layers
        // Using automapper to Map the Business DTOs and infrastructure Models from the different layers of the DDD architecture
        //private readonly Mapper _mapper;

        public IProductRepository _productRepository;
        public IEnumerable<Product> ProductsAvailableNow => _productsAvailableNow;

        public ProductService(IProductRepository productRepository)
        {
            _productsAvailableNow = new List<Product>();
            _productRepository = productRepository;
        }

        public IEnumerable<Product> ListAllProducts()
        {
            // I commented the following line since that was thought for the case where we a different DTO in each layer.
            // return _mapper.MapList<Infrastructure.Model.ProductModel, Product>(_productRepository.GetAllProducts().ToList());

            return _productRepository.GetAllProducts();
        }

        public void UpdateListOfAvailableProducts(int currentHour) // 'currentHour' will be DateTime.Now.Hour, it will just be modified in the tests
        {
            var productList = new List<Product>();

            foreach (var product in ListAllProducts())
            {
                if (IsAvailableProduct(product, currentHour))
                {
                    // Replaced the creation of a new Product, because we were basically creating a new instance of the existing 'product'
                    productList.Add(product);
                }
            }

            _productsAvailableNow = productList;
        }

        // Util function to now if the product is available atm, extracted from the main function to ease the logic of the caller and to 
        // have a different function that might be used in other methods
        // Pending to refactor the following function to another class to avoid mixing responsibilities of the ProductService and have to much code here.
        private bool IsAvailableProduct(Product product, int currentHour)
        {
            return product.ProductType == ProductType.AllDay || (product.StartHour <= currentHour && product.EndHour >= currentHour);
        }
    }

}
