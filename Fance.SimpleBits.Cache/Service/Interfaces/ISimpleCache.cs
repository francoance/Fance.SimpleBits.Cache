using System.Threading.Tasks;

namespace Fance.SimpleBits.Cache.Service.Interfaces
{
    public interface ISimpleCache
    {
        string Find(string key);
        void Save(string key, string value);
        Task<string> FindAsync(string key);
        Task SaveAsync(string key, string value);
    }
}