using Microsoft.Extensions.DependencyInjection;
using PayzaarTask.Business.Contract;
using PayzaarTask.Business.Impl;
using System;

namespace PayzaarTask.Business.Extension
{
    public static class BusinessModuleExtension
    {
        public static IServiceCollection AddBusinessServices(
           this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IProductService, ProductService>()
                .AddInfrastructureServices();

            return services;
        }
    }
}
