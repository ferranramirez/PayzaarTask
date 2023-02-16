using Microsoft.Extensions.DependencyInjection;
using PayzaarTask.Infrastructure.Contract;
using PayzaarTask.Infrastructure.Impl;
using System;

namespace PayzaarTask.Business.Extension
{
    public static class InfrastructureModuleExtension
    {
        public static IServiceCollection AddInfrastructureServices(
           this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
