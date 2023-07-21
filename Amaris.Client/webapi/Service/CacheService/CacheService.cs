using Amaris.WebAPI.Core.Employee.Interfaces;
using Amaris.WebAPI.Core.Helpers.Interfaces;
using Amaris.WebAPI.Models;
using Amaris.WebAPI.Service.CacheService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Amaris.WebAPI.Service.CacheService
{
    public class CacheService : ICacheService
    {
        #region Fields
        private readonly ICacheCore _cacheCore;
        #endregion

        #region Builder
        public CacheService(ICacheCore cacheCore)
        {
            _cacheCore = cacheCore;
        }
        #endregion

        #region Methods
        public async void Save(List<ResponseEmployeeDTO?>? employeeList)
        {
            await _cacheCore.AddDataToCache(employeeList);
        }

        public async Task<ResponseEmployeeDTO?> GetDataByIdFromCache(string id)
        {
            return await _cacheCore.GetDataByIdFromCache(id);
        }

        public async Task<List<ResponseEmployeeDTO?>?> GetAllDataFromCache()
        {
            return await _cacheCore.GetAllDataFromCache();
        }
        #endregion
    }
}
