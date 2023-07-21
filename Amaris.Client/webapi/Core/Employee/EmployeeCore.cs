using Amaris.WebAPI.Core.Employee.Interfaces;
using Amaris.WebAPI.Core.Helpers.Interfaces;
using Amaris.WebAPI.Core.RequestWebAPI.Interfaces;
using Amaris.WebAPI.Models;
using Amaris.WebAPI.Service.CacheService;
using Amaris.WebAPI.Service.CacheService.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Amaris.WebAPI.Core.Employee
{
    public class EmployeeCore : IEmployeeCore
    {
        #region Fields
        private readonly IRequestWebAPICore _requestWebAPICore;
        private readonly ICacheService _cacheService;
        #endregion

        #region Builder
        public EmployeeCore(IRequestWebAPICore requestWebAPICore, ICacheService cacheService)
        {
            _requestWebAPICore = requestWebAPICore;
            _cacheService = cacheService;
        }
        #endregion

        #region Methods
        public async Task<List<ResponseEmployeeDTO?>?> GetEmployeeAll()
        {
            try
            {
                List<ResponseEmployeeDTO?>? cacheList = _cacheService.GetAllDataFromCache().Result;
                if (cacheList == null || cacheList.Count == 0)
                {
                    string request = await _requestWebAPICore.CallApi();
                    if (request != null)
                    {
                        if (request != HttpStatusCode.TooManyRequests.ToString())
                        {
                            ResultRequestAllEmployeesDTO? employees = JsonConvert.DeserializeObject<ResultRequestAllEmployeesDTO?>(request);
                            if (employees?.Data is List<ResponseEmployeeDTO> employeeDataList)
                            {
                                List<ResponseEmployeeDTO?>? updatedList = CalculateAnualSalary(employeeDataList).Result;
                                _cacheService.Save(updatedList);
                                return updatedList;

                            }
                        }
                        return new List<ResponseEmployeeDTO?> {ResponseEmployeeDTO.TooManyRequest()};
                    }
                    return null;
                }
                return cacheList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ResponseEmployeeDTO?> GetEmployeeById(string idEmployee)
        {
            try
            {
                ResponseEmployeeDTO? cacheEmployee = _cacheService.GetDataByIdFromCache(idEmployee).Result;
                if (cacheEmployee == null)
                {
                    string request = await _requestWebAPICore.CallApi(idEmployee);
                    if (request != null)
                    {
                        if(request != HttpStatusCode.TooManyRequests.ToString())
                        {
                            ResultRequestByIdEmployeeDTO? employee = JsonConvert.DeserializeObject<ResultRequestByIdEmployeeDTO?>(request);
                            if (employee != null)
                            {
                                ResponseEmployeeDTO? data = employee.Data;
                                if (data != null)
                                {
                                    return CalculateAnualSalary(employee.Data).Result;
                                }
                            }
                            return null;
                        }

                        return ResponseEmployeeDTO.TooManyRequest();
                    }
                }
                return cacheEmployee;
            }
            catch (WebException)
            {
                return null;
            }
        }

        public async Task<List<ResponseEmployeeDTO?>?> CalculateAnualSalary(List<ResponseEmployeeDTO?> employeeList)
        {
            foreach (ResponseEmployeeDTO? item in employeeList)
            {
                item.Employee_anual_salary = item.Employee_salary * 12; 
            }
            return await Task.FromResult(employeeList);  
        }

        public async Task<ResponseEmployeeDTO?> CalculateAnualSalary(ResponseEmployeeDTO? employee)
        {
            employee.Employee_anual_salary = employee.Employee_salary * 12;
            return employee ;
        }
        #endregion
    }
}
