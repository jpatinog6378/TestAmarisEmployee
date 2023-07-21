using Amaris.WebAPI.Models;
using System.Net;

namespace Amaris.WebAPI.Core.Employee.Interfaces
{
    public interface IEmployeeCore
    {
        Task<ResponseEmployeeDTO?> GetEmployeeById(string idEmployee);
        Task<List<ResponseEmployeeDTO?>?> GetEmployeeAll();
        Task<List<ResponseEmployeeDTO?>?> CalculateAnualSalary(List<ResponseEmployeeDTO> employeeList);
    }
}
