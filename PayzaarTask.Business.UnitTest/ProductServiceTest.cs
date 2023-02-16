using Moq;
using PayzaarTask.Business.Contract;
using PayzaarTask.Business.Impl;
using PayzaarTask.Business.UnitTest.Utils;
using PayzaarTask.Infrastructure;
using PayzaarTask.Infrastructure.Contract;
using PayzaarTask.Infrastructure.Model;
using System.Collections.Generic;
using Xunit;

namespace PayzaarTask.Business.UnitTest
{
    public class ProductServiceTest : IClassFixture<RepositoryMockUtils>
    {
        public IProductService _productService;
        public Mock<IProductRepository> _productRepository;

        public List<Product> allProductsMock;

        public ProductServiceTest(RepositoryMockUtils repositoryMockUtils)
        {
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object);

            allProductsMock = repositoryMockUtils.GetAllProductsMock();
        }

        [Fact]
        public void ListAllProducts_Returns_AllProductNames()
        {
            // Arrange
            _productRepository.Setup(pr => pr.GetAllProducts()).Returns(allProductsMock);
            List<Product> expected = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = ProductType.AllDay },
                new Product { ProductName = "Breakfast Burrito", ProductType = ProductType.Limited, StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = ProductType.Limited, StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = ProductType.Limited, StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = ProductType.Limited, StartHour = 17, EndHour = 23 }
            };

            // Act
            var actual = _productService.ListAllProducts();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateProducts_Returns_AllDayProducts_AccordingToHour1()
        {
            // Arrange
            _productRepository.Setup(pr => pr.GetAllProducts()).Returns(allProductsMock);
            List<Product> expected = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = ProductType.AllDay }
            };

            // Act
            _productService.UpdateListOfAvailableProducts(1);

            var actual = _productService.ProductsAvailableNow;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateProducts_Returns_UpdatedProducts_AccordingToHour23()
        {
            // Arrange
            _productRepository.Setup(pr => pr.GetAllProducts()).Returns(allProductsMock);
            List<Product> expected = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = ProductType.AllDay },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = ProductType.Limited, StartHour = 17, EndHour = 23 }
            };

            // Act
            _productService.UpdateListOfAvailableProducts(23);

            var actual = _productService.ProductsAvailableNow;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
