using BLL.Interfaces;
using BLL.Repository;
using BLL.Services;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinesslogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessLayer(configuration);
            services.AddScoped<IProductRepository, ProductRepositoryMoq>();
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddScoped<IUserRepository, UserRepositoryMoq>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IUserService, UserServices>();
            //services.AddTransient<IUserService, UserServicesDal>();
            services.AddScoped<IPaymaentServices, LiqPayServicies>();
            services.AddScoped<GoogleServices>();
            services.AddAutoMapper(typeof(AppMappingProfile));
            return services;
        }
    }
}