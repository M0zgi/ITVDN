using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinesslogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepositoryMoq>();
            services.AddScoped<IProductServices, ProductServices>();

            return services;
        }
    }
}