namespace Amaris.WebAPI.Models
{
    public class EmployeeDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Employee_name { get; set; } = string.Empty;
        public int Employee_salary { get; set; }
        public int Employee_age { get; set; }
    }
}
