using Amaris.WebAPI.Core.Helpers.Interfaces;
using Amaris.WebAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Amaris.WebAPI.Core.Helpers
{
    public class CacheCore : ICacheCore
    {
        #region Fields
        private readonly IMemoryCache _cache;
        #endregion

        #region Builder
        public CacheCore(IMemoryCache cache)
        {
            _cache = cache;
        }
        #endregion

        #region Methods
        public async Task AddDataToCache(List<ResponseEmployeeDTO?>? data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) 
            };
            foreach (ResponseEmployeeDTO? item in data)
            {
                _cache.Set(item.Id, item, cacheEntryOptions);
            }
            _cache.Set("ALL", data, cacheEntryOptions);
        }

        public async Task<List<ResponseEmployeeDTO?>?> GetAllDataFromCache()
        {
            return await Task.FromResult(_cache?.Get("ALL") as List<ResponseEmployeeDTO?>);
        }

        public async Task<ResponseEmployeeDTO?> GetDataByIdFromCache(string id)
        {
            return await Task.FromResult((ResponseEmployeeDTO?) _cache.Get(id));
        }
        #endregion
    }
}
