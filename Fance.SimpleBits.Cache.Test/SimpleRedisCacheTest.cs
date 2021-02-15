using System.Threading.Tasks;
using Fance.SimpleBits.Cache.Service;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fance.SimpleBits.Cache.Test
{
    /// <summary>
    /// Unit tests for SimpleRedisCache.
    /// </summary>
    [TestClass]
    public class SimpleRedisCacheTest
    {
        private readonly IDistributedCache _distributedCache;
        private readonly SimpleRedisCache _redisCacheService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SimpleRedisCacheTest()
        {
            // Using Memory cache instead of mocking.
            // Not sure that IDistributedCache can actually be mocked with Moq.
            var opts = Options.Create(new MemoryDistributedCacheOptions());
            _distributedCache = new MemoryDistributedCache(opts);
            _redisCacheService = new SimpleRedisCache(_distributedCache);
        }
        
        /// <summary>
        /// Validate that the Save method stores the data.
        /// </summary>
        [TestMethod]
        public void Save_Success()
        {
            // Assign
            const string key = "key";
            const string value = "value";
            
            // Act
            _redisCacheService.Save(key, value);
            
            // Assert
            var cachedValue = _distributedCache.GetString(key);
            Assert.IsNotNull(cachedValue);
            Assert.AreEqual(value, cachedValue);
        }
        
        /// <summary>
        /// Validate that the SaveAsync method stores the data.
        /// </summary>
        [TestMethod]
        public async Task SaveAsync_Success()
        {
            // Assign
            const string key = "key";
            const string value = "value";
            
            // Act
            await _redisCacheService.SaveAsync(key, value);
            
            // Assert
            var cachedValue = await _distributedCache.GetStringAsync(key);
            Assert.IsNotNull(cachedValue);
            Assert.AreEqual(value, cachedValue);
        }
        
        /// <summary>
        /// Validate that the Find method retrieves the stored data.
        /// </summary>
        [TestMethod]
        public void Find_Success()
        {
            // Assign
            const string key = "key";
            const string expectedValue = "value";
            _distributedCache.SetString(key, expectedValue);
            
            // Act
            var result = _redisCacheService.Find(key);
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);
        }
        
        /// <summary>
        /// Validate that the Find method returns null when the key doesn't exist.
        /// </summary>
        [TestMethod]
        public void Find_ReturnsNull()
        {
            // Assign
            const string key = "key";
            
            // Act
            var result = _redisCacheService.Find(key);
            
            // Assert
            Assert.IsNull(result);
        }
        
        /// <summary>
        /// Validate that the FindAsync method retrieves the stored data.
        /// </summary>
        [TestMethod]
        public async Task FindAsync_Success()
        {
            // Assign
            const string key = "key";
            const string expectedValue = "value";
            await _distributedCache.SetStringAsync(key, expectedValue);
            
            // Act
            var result = await _redisCacheService.FindAsync(key);
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);
        }
        
        /// <summary>
        /// Validate that the FindAsync method returns null when the key doesn't exist.
        /// </summary>
        [TestMethod]
        public async Task FindAsync_ReturnsNull()
        {
            // Assign
            const string key = "key";
            
            // Act
            var result = await _redisCacheService.FindAsync(key);
            
            // Assert
            Assert.IsNull(result);
        }
    }
}