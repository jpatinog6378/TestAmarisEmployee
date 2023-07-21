using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amaris.WebAPI.Models
{
    public class ResponseEmployeeDTO : EmployeeDTO
    {
        public int Employee_anual_salary { get; set; }
        internal Boolean _Too_Many_Request;

        public static ResponseEmployeeDTO TooManyRequest()
        {
            ResponseEmployeeDTO responseEmployeeDTO = new ResponseEmployeeDTO();
            responseEmployeeDTO._Too_Many_Request = true;
            return responseEmployeeDTO;
        }

        public Boolean IsTooManyRequest() { return _Too_Many_Request; }
    }
}
