using Amaris.WebAPI.Models;

namespace Amaris.WebAPI.Core.Helpers.Interfaces
{
    public interface ICacheCore
    {
        Task<ResponseEmployeeDTO?> GetDataByIdFromCache(string id);
        Task<List<ResponseEmployeeDTO?>> GetAllDataFromCache(); 
        Task AddDataToCache(List<ResponseEmployeeDTO?>? data);
    }
}
