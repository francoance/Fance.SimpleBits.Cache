using System.Threading.Tasks;
using Fance.SimpleBits.Cache.Service.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Fance.SimpleBits.Cache.Service
{
    public class SimpleRedisCache : ISimpleCache
    {
        private readonly IDistributedCache _redisClient;

        public SimpleRedisCache(IDistributedCache redisClient)
        {
            _redisClient = redisClient;
        }

        public string Find(string key)
        {
            return _redisClient.GetString(key);
        }

        public void Save(string key, string value)
        {
            _redisClient.SetString(key, value);
        }

        public async Task<string> FindAsync(string key)
        {
            return await _redisClient.GetStringAsync(key);
        }

        public async Task SaveAsync(string key, string value)
        {
            await _redisClient.SetStringAsync(key, value);
        }
    }
}