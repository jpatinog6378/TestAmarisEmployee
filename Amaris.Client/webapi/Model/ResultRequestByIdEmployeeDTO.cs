namespace Amaris.WebAPI.Models
{
    public class ResultRequestByIdEmployeeDTO
    {
        public string Status { get; set; } = string.Empty;
        public ResponseEmployeeDTO? Data { get; set; }
        public string? Message { get; set; }
    }
}
