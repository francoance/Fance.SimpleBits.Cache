using Fance.SimpleBits.Cache.Service;
using Fance.SimpleBits.Cache.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fance.SimpleBits.Cache.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSimpleCache(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("Cache");
            services.AddStackExchangeRedisCache(setup =>
            {
                setup.Configuration = config.GetSection("Host").Value;
            });
            services.AddSingleton<ISimpleCache, SimpleRedisCache>();
        }
    }
}