namespace Amaris.WebAPI.Models
{
    public class ResultRequestAllEmployeesDTO
    {
        public string Status { get; set; } = string.Empty;
        public List<ResponseEmployeeDTO?>? Data { get; set; }
        public string? Message { get; set; }
    }
}
