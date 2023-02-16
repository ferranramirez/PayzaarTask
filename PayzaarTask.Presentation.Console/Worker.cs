/*
 * TODO:
 *	- refactor, find all the issues you can and fix them
 *	- change the code to follow clean architecture principles
 *	- apply design patterns where you think it is required
 *	- do not change the output
 *	- make sure the refactored code is testable (you are allowed to write a test or two as a PoC)
 *	- add comments, highlighting what you changed and what was the reason for change
 */

using Microsoft.Extensions.Hosting;
using PayzaarTask.Business.Contract;
using PayzaarTask.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PayzaarRefactorCodingTask
{
    public class Worker : BackgroundService
    {
        public static IProductService _productService;
        private readonly IHost _host;

        public Worker(IHost host, IProductService productService)
        {
            _host = host;
            _productService = productService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine(DisplayProductsAvailability());
            Console.ReadKey();

            await _host.StopAsync();
        }


        private static string DisplayProductsAvailability()
        {
            _productService.UpdateListOfAvailableProducts(DateTime.Now.Hour);

            if (_productService.ProductsAvailableNow.Any())
            {
                return GetProductsAvailableNowText();
            }

            return "There are no products available at this time of day";
        }

        private static string GetProductsAvailableNowText()
        {
            string displayText = "Products available at the current time of the day:";

            foreach (var productAvailableNow in _productService.ProductsAvailableNow)
            {
                string displayName = productAvailableNow.ProductName;

                if (productAvailableNow.ProductType == ProductType.AllDay)
                    displayText = string.Concat(displayText, "\n", displayName);
                else
                {
                    displayName += " (" + productAvailableNow.StartHour + ":00" + "-" + productAvailableNow.EndHour + ":00" + ")";
                    displayText = string.Concat(displayText, "\n", displayName);
                }
            }

            return displayText;
        }
    }
}
