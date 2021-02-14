using System.Threading.Tasks;
using Fance.SimpleBits.Cache.Service.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Fance.SimpleBits.Cache.Service
{
    /// <summary>
    /// Simple Cache implementation for Redis.
    /// </summary>
    public class SimpleRedisCache : ISimpleCache
    {
        private readonly IDistributedCache _redisClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="redisClient">Redis client.</param>
        public SimpleRedisCache(IDistributedCache redisClient)
        {
            _redisClient = redisClient;
        }

        /// <summary>
        /// Find a string by its key.
        /// </summary>
        /// <param name="key">Object's key.</param>
        /// <returns>String found for the key.</returns>
        public string Find(string key)
        {
            return _redisClient.GetString(key);
        }

        /// <summary>
        /// Save an object with a key.
        /// </summary>
        /// <param name="key">Key for the object.</param>
        /// <param name="value">String value object.</param>
        public void Save(string key, string value)
        {
            _redisClient.SetString(key, value);
        }

        /// <summary>
        /// Find a string by its key, asynchronically.
        /// </summary>
        /// <param name="key">Object's key.</param>
        /// <returns>String found for the key.</returns>
        public async Task<string> FindAsync(string key)
        {
            return await _redisClient.GetStringAsync(key);
        }

        /// <summary>
        /// Save an object with a key, asynchronically.
        /// </summary>
        /// <param name="key">Key for the object.</param>
        /// <param name="value">String value object.</param>
        public async Task SaveAsync(string key, string value)
        {
            await _redisClient.SetStringAsync(key, value);
        }
    }
}