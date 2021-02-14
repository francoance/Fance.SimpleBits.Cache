using System.Threading.Tasks;

namespace Fance.SimpleBits.Cache.Service.Interfaces
{
    /// <summary>
    /// Simple Cache interface.
    /// </summary>
    public interface ISimpleCache
    {
        /// <summary>
        /// Find a string by its key.
        /// </summary>
        /// <param name="key">Object's key.</param>
        /// <returns>String found for the key.</returns>
        string Find(string key);
        
        /// <summary>
        /// Save an object with a key.
        /// </summary>
        /// <param name="key">Key for the object.</param>
        /// <param name="value">String value object.</param>
        void Save(string key, string value);
        
        /// <summary>
        /// Find a string by its key, asynchronically.
        /// </summary>
        /// <param name="key">Object's key.</param>
        /// <returns>String found for the key.</returns>
        Task<string> FindAsync(string key);
        
        /// <summary>
        /// Save an object with a key, asynchronically.
        /// </summary>
        /// <param name="key">Key for the object.</param>
        /// <param name="value">String value object.</param>
        Task SaveAsync(string key, string value);
    }
}