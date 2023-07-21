using Amaris.WebAPI.Core.Employee.Interfaces;
using Amaris.WebAPI.Core.Helpers.Interfaces;
using Amaris.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amaris.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        #region Fields
        private readonly IEmployeeCore _employeeCore;
        #endregion

        #region Builder
        public EmployeeController(IEmployeeCore employeeCore) 
        {
            _employeeCore = employeeCore; 
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetEmployeeById( string idEmployee = "")
        {
            var response = await _employeeCore.GetEmployeeById(idEmployee);
            return response != null ? 
                !response.IsTooManyRequest() ?
                    Ok(response)
                    : BadRequest()
                : NotFound(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeAll()
        {
            var response = await _employeeCore.GetEmployeeAll();
            return response != null ?
                !response[0].IsTooManyRequest() ?
                    Ok(response)
                    : BadRequest()
                : NotFound(response);
        }
        #endregion
    }
}
