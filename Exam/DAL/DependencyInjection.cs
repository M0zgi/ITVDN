using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(options =>
            {
                return new EntityDatabase(configuration.GetConnectionString("DbConnect"));
            });
            services.AddScoped<IUserRepositoryDal, UserServices>();
           

            return services;
        }
    }
}
