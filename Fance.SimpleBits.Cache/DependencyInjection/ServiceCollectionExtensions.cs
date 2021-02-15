using System.Text;
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
            var connectionString = GetConnectionStringFromConfiguration(configuration);
            services.AddStackExchangeRedisCache(setup =>
            {
                setup.Configuration = connectionString;
            });
            services.AddSingleton<ISimpleCache, SimpleRedisCache>();
        }
    
        /// <summary>
        /// Build a redis connection string from the configuration object. 
        /// </summary>
        /// <param name="configuration">Configuration object.</param>
        /// <returns>Redis connection string.</returns>
        private static string GetConnectionStringFromConfiguration(IConfiguration configuration)
        {
            var connectionString = new StringBuilder();

            var host = configuration.GetSection("Cache:Host").Value ?? "localhost:6379";
            connectionString.Append(host);

            var password = configuration.GetSection("Cache:Password").Value;
            if (password != null)
            {
                connectionString.Append(",password=" + password);
            }
            
            return connectionString.ToString();
        }
    }
}