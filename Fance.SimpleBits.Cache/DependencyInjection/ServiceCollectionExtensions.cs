using Fance.SimpleBits.Cache.Service;
using Fance.SimpleBits.Cache.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fance.SimpleBits.Cache.DependencyInjection
{
    /// <summary>
    /// Extension methods for the service collection.
    /// Used to add services to the dependency injector container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the simple redis cache.
        /// Configures the StackExchangeRedisCache library from Microsoft nuget package.
        /// Registers ISimpleCache using the SimpleRedisCache type.
        /// </summary>
        /// <param name="services">Service collector.</param>
        /// <param name="configuration">Configuration object.</param>
        public static void AddSimpleRedisCache(this IServiceCollection services, IConfiguration configuration)
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