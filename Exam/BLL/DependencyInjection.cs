using BLL.Interfaces;
using BLL.Repository;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinesslogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepositoryMoq>();
            services.AddScoped<IUserRepository, UserRepositoryMoq>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IPaymaentServices, LiqPayServicies>();
            services.AddScoped<GoogleServices>();

            return services;
        }
    }
}