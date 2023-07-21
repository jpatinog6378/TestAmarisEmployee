using Amaris.WebAPI.Models;

namespace Amaris.WebAPI.Service.CacheService.Interfaces
{
    public interface ICacheService
    {
        void Save(List<ResponseEmployeeDTO?>? employeeList);
        Task<ResponseEmployeeDTO?> GetDataByIdFromCache(string id);
        Task<List<ResponseEmployeeDTO?>?> GetAllDataFromCache();
    }
}
